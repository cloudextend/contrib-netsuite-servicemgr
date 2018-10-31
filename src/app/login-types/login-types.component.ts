import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';


@Component({
    selector: 'app-login-types',
    templateUrl: './login-types.component.html',
    styleUrls: ['./login-types.component.css']
})
export class LoginTypesComponent implements OnInit {

    userEmail: string;
    showBasic: boolean;
    showTBA: boolean;
    showSSO: boolean;

    accounts: object[];
    selectedAccount: object;

    constructor(
        private route: ActivatedRoute,
        private http: Http
    ) {
        const loginMethods = {
            'celigo-basic': 'basic',
            'celigo-tba': 'tba',
            'celigo-sso': 'sso',
        };
        this.selectedAccount = {
            accountName: 'choose an account',
            basic: false,
            tba: false,
            sso: false
        };

        this.userEmail = this.route.snapshot.queryParams.email;
        this.http.get('https://00a817a2.ap.ngrok.io/api/netsuite/2.0/auth/type?' +
            `email=${this.route.snapshot.queryParams.email}`
        )
        .map(resp => resp.json())
        .subscribe((response) => {
            const { accounts } = response;

            this.accounts = accounts.map(({account, methods}) => {
                const loginMap = methods.reduce((map, {method, enabled }) => {
                    map[loginMethods[method]] = enabled;

                    return map;
                }, {});

                return {
                    accountName: account.name,
                    ...loginMap
                };
            });

            this.selectedAccount = this.accounts[0];

            console.log(this.accounts);

            // this.showBasic = basic;
            // this.showTBA = tba;
            // this.showSSO = sso;
        });
    }

    ngOnInit() {
    }
}
