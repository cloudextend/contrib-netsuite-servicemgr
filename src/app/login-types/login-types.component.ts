import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';

import { AuthUserPreferencesService, TokenService } from 'lib-client-auth-netsuite';

enum LoginMethodsFetchStates {
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
        private router: Router,
        private userPreferenceService: AuthUserPreferencesService,
        private tokenService: TokenService,
    ) {}

    ngOnInit() {
        this.userEmail = this.userPreferenceService.getDefaultEmail();

        this.http
        .get(`https://00a817a2.ap.ngrok.io/api/netsuite/2.0/auth/type?email=${this.userEmail}`)
        .map(resp => resp.json())
        .subscribe((response) => {
            const { basic, tba, sso } = response;

            this.basic = basic;
            this.tba = tba;
            this.sso = sso;

            this.fetchState = LoginMethodsFetchStates.Done;

            console.log({sso});
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
