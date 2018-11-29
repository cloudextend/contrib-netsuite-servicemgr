import { Component, OnInit, AfterViewInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import {
    AuthUserPreferencesService, LoginStates, SsoFlowStates, TbaPersistedStates, TokenService, SsoLoginViewComponent
} from 'lib-client-auth-netsuite';

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
    userEmail: string;
    persistTokens: boolean;
    tagName: string;

    account: string;
    token: string;
    tokenSecret: string;

    hasASavedPin: boolean;

    tokens = [];

    loginFailed = false;

    @ViewChild(SsoLoginViewComponent) ssoLoginComponentRef: SsoLoginViewComponent;

    private $ = (<any>window).$;

    constructor(
        private changeDetector: ChangeDetectorRef,
        private officeService: OfficeService,
        private route: ActivatedRoute,
        private storage: StorageService,
        private tokenService: TokenService,
        private userPreferenceService: AuthUserPreferencesService,
    ) {
        this.persistTokens = true;
    }

    ngOnInit() {
        this.type = this.route.snapshot.params.type;
        this.accountId = this.route.snapshot.queryParams.accountId;

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

    onBasicLoginStateChange({state, data}) {
        this.loginFailed = false;

        data.credentialType = 'celigo-basic';

        data.user = {...data.user, email: this.userEmail};

        console.log('onBasicLoginStateChange, event:', {state, data});

        if (state === LoginStates.Success) {
            this.storage.set('celigo_cexl_session_data', data);
            this.redirectToCEXLApp();
        } else if (state === LoginStates.FailedAuth) {
            this.loginFailed = true;
        }
    }

    onTBALoginStateChange(event) {
        const {data, inputs: {account, token, tokenSecret}} = event;

        data.credentialType = 'celigo-tba';

        data.user = {...data.user, email: this.userEmail};

        console.log(event);

        if (event.state === LoginStates.Success) {
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
    }

    onInitiateSSOFlow(event) {
        if (event === SsoFlowStates.AttemptInProgress) {
            const {base, initiateSSO} = environment.urls.authAPI;

            this.officeService.openDialog(
                `${base}${initiateSSO}?accountId=${this.accountId}`,
                ({ dialog, response: {message}}) => {
                    try {
                        const {tbaClaims = []} = JSON.parse(message);

                        this.tokens = tbaClaims;

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
        data.credentialType = 'celigo-tba';

        data.user = {...data.user, email: this.userEmail};

        console.log('onSSOLoginStateChange, event:', {state, data});

        if (state === LoginStates.Success) {
            this.storage.set('celigo_cexl_session_data', data);
            this.redirectToCEXLApp();
        }
    }
}
