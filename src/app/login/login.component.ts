import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthUserPreferencesService, LoginStates, SsoFlowStates, TbaPersistedStates, TokenService } from 'lib-client-auth-netsuite';

import { OfficeService } from '../office.service';
import { StorageService } from '../storage.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    type: string;
    userEmail: string;
    persistTokens: boolean;
    tagName: string;

    account: string;
    token: string;
    tokenSecret: string;

    hasASavedPin: boolean;

    private $ = (<any>window).$;

    constructor(
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
        this.userEmail = this.userPreferenceService.getDefaultEmail();

        this.tagName = this.tokenService.generateTagName('AccountId');
    }

    onBasicLoginStateChange({state, data}) {
        data.credentialType = 'celigo-basic';

        data.user = {...data.user, email: this.userEmail};

        console.log({state, data});

        if (LoginStates[state] === 'Success') {
            this.storage.set('celigo_cexl_session_data', data);

            window.location.href = 'https://00a817a2.ap.ngrok.io/';
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

            window.location.href = 'https://00a817a2.ap.ngrok.io/';
        }
    }

    onTokenPersistStateChanged(event) {
        if (event.state === TbaPersistedStates.SuccessfullySavedTokens) {
            this.$('#confirmPinModal').modal('hide');

            window.location.href = 'https://00a817a2.ap.ngrok.io/';
        }
    }

    onInitiateSSOFlow(event) {
        if (event === SsoFlowStates.AttemptInProgress) {
            console.log('in progress');

            const ssoSignUrl = 'https://00a817a2.ap.ngrok.io/api/netsuite/2.0/auth/initiate-sso';
            this.officeService.openDialog(ssoSignUrl , (data) => {
                console.log(data);
            });
        }
    }
}
