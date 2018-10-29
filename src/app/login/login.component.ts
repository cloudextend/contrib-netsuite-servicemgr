import { Component, OnInit, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginStates, AuthService } from 'lib-client-auth-netsuite';

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

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private storage: StorageService,
    ) {}

    ngOnInit() {
        this.type = this.route.snapshot.params.type;
        this.userEmail = this.route.snapshot.queryParams.email;
    }

    onBasicLoginStateChange({state, data}) {
        data.credentialType = 'celigo-basic';

        data.user = {...data.user, email: this.userEmail};

        console.log({state, data});

        if (LoginStates[state] === 'Success') {
            this.storage.set('celigo_cexl_session_data', data);
        }
    }

    onTBALoginStateChange(event) {
        const {inputs: {account, token, tokenSecret}} = event;

        console.log(event);

        if (event.state === LoginStates.Success) {
            this.storage.set('celigo_cexl_session_data', event.data);

            if (this.persistTokens) {
                const queryParams = {account, token, tokenSecret, email: this.userEmail};
                this.router.navigate(['login', 'tba', 'persist-tokens'], { queryParams });
            }
        }
    }
}
