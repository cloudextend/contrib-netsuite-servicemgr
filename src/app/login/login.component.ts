import { Component, OnInit, AfterViewInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';

import {
    AuthUserPreferencesService, LoginStates, SsoFlowStates, TbaPersistedStates,
    TokenService, SsoLoginViewComponent, UserProfileService
} from 'lib-client-auth-netsuite';

import { LoaderService } from '../loader.service';
import { OfficeService } from '../office.service';
import { StorageService } from '../storage.service';

import { environment } from '../../environments/environment';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, AfterViewInit {

    type: string;
    accountId: string;
    isNewUser: boolean;
    userEmail: string;
    persistTokens: boolean;
    tagName: string;

    account: string;
    token: string;
    tokenSecret: string;

    hasASavedPin: boolean;

    ssoTokenList = [];

    loginFailed = false;

    isInvalidTBAPin = false;

    duplicateTBATokenEntered = false;

    @ViewChild(SsoLoginViewComponent) ssoLoginComponentRef: SsoLoginViewComponent;

    private $ = (<any>window).$;

    constructor(
        private changeDetector: ChangeDetectorRef,
        private http: Http,
        private loader: LoaderService,
        private officeService: OfficeService,
        private route: ActivatedRoute,
        private storage: StorageService,
        private tokenService: TokenService,
        private userProfileService: UserProfileService,
        private userPreferenceService: AuthUserPreferencesService,
    ) {
        this.persistTokens = true;
    }

    ngOnInit() {
        this.type = this.route.snapshot.params.type;
        this.accountId = this.route.snapshot.queryParams.accountId;
        this.isNewUser = this.route.snapshot.queryParams.isNewUser === 'true';

        this.userEmail = this.userPreferenceService.getDefaultEmail();

        this.tagName = this.tokenService.generateTagName('AccountId');
    }

    ngAfterViewInit() {
        if (this.type === 'sso') {
            this.ssoLoginComponentRef.initiateSso();
        }
    }

    private redirectToCEXLApp() {
        window.location.href = environment.urls.cexlApp;
    }

    private waitForLicense({email, interval = 3000, attempts = 20}) {
        let count = 0;
        let intervalHandle = null;

        const {base, licenseCheck} = environment.urls.backend;

        return new Promise((resolve, reject) => {
            intervalHandle = setInterval(() => {
                return this.http.get(`${base}${licenseCheck}?system=netsuite&type=in_trial&email=${email}`)
                .map(resp => resp.json())
                .toPromise()
                .then(licenseDetails => {
                    clearInterval(intervalHandle);
                    resolve({
                        success: true,
                        license: licenseDetails
                    });
                })
                .catch(error => {
                    if (count < attempts) { count += 1; return; }

                    clearInterval(intervalHandle);

                    reject({
                        success: false,
                        error: 'failed to get license details',
                        details: error
                    });
                });
            }, interval);
        });
    }

    onBasicLoginStateChange({state, data}) {
        if (state === LoginStates.AttemptInProgress) {
            this.loader.setMessage('Logging you in...');
            this.loader.show();
            return;
        }

        this.loader.hide();
        this.loginFailed = false;

        data.credentialType = 'celigo-basic';

        data.user = {...data.user, email: this.userEmail};

        console.log('onBasicLoginStateChange, event:', {state, data});

        if (state === LoginStates.FailedAuth) {
            this.loginFailed = true;

            return;
        }

        if (state === LoginStates.Success) {
            this.storage.set('celigo_cexl_session_data', data);

            if (this.isNewUser) {
                // handle new user flow - activate trial for the user
                const {base, trialActivation} = environment.urls.backend;
                const postData = this.userProfileService.getUserProfile();

                (<any>postData).trialEmail = postData.email;
                postData.email = this.userEmail;

                this.loader.setMessage('Activating your trial...');
                this.loader.show();

                this.http.post(`${base}${trialActivation}?system=netsuite`, postData)
                .map(resp => resp.json())
                .toPromise()
                .then(activationDetails => {
                    this.loader.setMessage('Waiting for Activation confirmation...');
                    return this.waitForLicense( { email: this.userEmail } )
                    .then(() => {
                        this.loader.hide();
                        this.redirectToCEXLApp();
                    });
                })
                .catch(error => {
                    console.log(error);
                    console.log(Object.keys(error));

                    const err = error.json();

                    if (err.title === 'User already has a license') {
                        // User already has a license
                    }

                    this.loader.hide();
                });

                return;
            }

            this.redirectToCEXLApp();

            return;
        }
    }

    onTBALoginStateChange({state, data, inputs: {account, token, tokenSecret}}) {
        if (state === LoginStates.AttemptInProgress) {
            this.loader.setMessage('Logging you in...');
            this.loader.show();
            return;
        }

        this.loader.hide();
        this.loginFailed = false;

        data.credentialType = 'celigo-tba';

        data.user = {...data.user, email: this.userEmail};

        if (state === LoginStates.FailedAuth) {
            this.loginFailed = true;
            return;
        }

        if (state === LoginStates.Success) {
            this.storage.set('celigo_cexl_session_data', data);

            if (this.persistTokens) {
                this.account = account;
                this.token = token;
                this.tokenSecret = tokenSecret;

                this.hasASavedPin = this.tokenService.hasSavedPin();

                this.$('#confirmPinModal').modal('show');

                return;
            }

            this.redirectToCEXLApp();
        }
    }

    onTokenPersistStateChanged(event) {
        if (event.state === TbaPersistedStates.SuccessfullySavedTokens) {
            this.$('#confirmPinModal').modal('hide');
            this.redirectToCEXLApp();
        }
        else if (event.state === TbaPersistedStates.InvalidPin) {
            this.isInvalidTBAPin = true;
            setTimeout(() => { this.isInvalidTBAPin = false; }, 3000);
        }
        else if (event.state === TbaPersistedStates.FailedToSaveTokensSinceDuplicate) {
            this.duplicateTBATokenEntered = true;

            setTimeout(() => {
                this.duplicateTBATokenEntered = false;
                this.redirectToCEXLApp();
            }, 5000);
        }
    }

    onInitiateSSOFlow(event) {
        if (event === SsoFlowStates.AttemptInProgress) {
            const {base, initiateSSO} = environment.urls.backend;

            this.officeService.openDialog(
                `${base}${initiateSSO}?accountId=${this.accountId}`,
                ({ dialog, response: {message}}) => {
                    try {
                        const {tbaClaims = []} = JSON.parse(message);

                        this.ssoTokenList = tbaClaims;

                        this.ssoLoginComponentRef.setState(SsoFlowStates.Success);

                        this.changeDetector.detectChanges();

                        dialog.close();
                    } catch (error) {
                        console.log(error);
                    }
                }
            );
        }
    }

    onSSOLoginStateChange({state, data}) {
        if (state === LoginStates.AttemptInProgress) {
            this.loader.setMessage('Logging you in...');
            this.loader.show();

            return;
        }

        this.loader.hide();
        data.credentialType = 'celigo-tba';

        data.user = {...data.user, email: this.userEmail};

        console.log('onSSOLoginStateChange, event:', {state, data});

        if (state === LoginStates.Success) {
            this.storage.set('celigo_cexl_session_data', data);
            this.redirectToCEXLApp();
        }
    }
}
