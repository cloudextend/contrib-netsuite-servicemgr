import { Component, OnInit, AfterViewInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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

    constructor(
        private route: ActivatedRoute,
        private storage: StorageService,
    ) {}

    ngOnInit() {
        this.type = this.route.snapshot.params.type;
        this.userEmail = this.route.snapshot.queryParams.email;
    }

    onBasicLoginStateChange(event) {
        console.log(event);

        if (LoginStates[event.state] === 'Success') {
            this.storage.set('celigo_cexl_session_data', event.data);
        }
    }

    onTBALoginStateChange(event) {
        console.log(event);

        if (LoginStates[event.state] === 'Success') {
            this.storage.set('celigo_cexl_session_data', event.data);
        }
    }
}
