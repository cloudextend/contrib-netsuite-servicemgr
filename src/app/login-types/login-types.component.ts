import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';

import { AuthUserPreferencesService, TokenService } from 'lib-client-auth-netsuite';

import { environment } from './../../environments/environment';
import { LoaderService } from '../loader.service';

export enum LoginMethodsFetchStates {
    Fetching,
    Done,
    Failed
}

@Component({
    selector: 'app-login-types',
    templateUrl: './login-types.component.html',
    styleUrls: ['./login-types.component.css']
})
export class LoginTypesComponent implements OnInit {

    userEmail: string;

    basic: object;
    tba: object;
    sso: object;

    loginMethodsFetchStates = LoginMethodsFetchStates;
    fetchState: LoginMethodsFetchStates = LoginMethodsFetchStates.Fetching;

    constructor(
        private http: Http,
        private loader: LoaderService,
        private router: Router,
        private userPreferenceService: AuthUserPreferencesService,
        private tokenService: TokenService,
    ) {}

    ngOnInit() {
        this.userEmail = this.userPreferenceService.getDefaultEmail();

        const {base, loginMethods} = environment.urls.backend;

        this.loader.setMessage('Fetching your login methods...');
        this.loader.show();

        this.http.get(`${base}${loginMethods}?email=${this.userEmail}`)
        .map(resp => resp.json())
        .subscribe((response) => {
            const { isNewUser, basic, tba, sso } = response;

            if (isNewUser) {
                this.router.navigate(['trial']);
                this.loader.hide();

                return;
            }

            this.basic = basic;
            this.tba = tba;
            this.sso = sso;

            this.fetchState = LoginMethodsFetchStates.Done;
            this.loader.hide();
        },
        (error) => { this.fetchState = LoginMethodsFetchStates.Failed; });
    }

    onTBASelection(event) {
        if (this.tokenService.hasSavedTokens()) {
            this.router.navigate(['login', 'tba', 'unlock-tokens']);

            return;
        }

        this.router.navigate(['login', 'tba']);
    }
}
