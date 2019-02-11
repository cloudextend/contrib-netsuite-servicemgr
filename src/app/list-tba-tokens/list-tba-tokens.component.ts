import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { AuthUserPreferencesService, LoginStates } from 'lib-client-auth-netsuite';

import { LoaderService } from '../loader.service';
import { StorageService } from '../storage.service';
import { environment } from '../../environments/environment';

@Component({
    selector: 'app-list-tba-tokens',
    templateUrl: './list-tba-tokens.component.html',
    styleUrls: ['./list-tba-tokens.component.css']
})
export class ListTbaTokensComponent implements OnInit {
    pin: string;
    userEmail: string;

    constructor(
        private loader: LoaderService,
        private route: ActivatedRoute,
        private router: Router,
        private storage: StorageService,
        private userPreferenceService: AuthUserPreferencesService,
    ) { }

    ngOnInit() {
        this.pin = this.route.snapshot.queryParams.pin;
        this.userEmail = this.userPreferenceService.getDefaultEmail();
    }

    private redirectToCEXLApp() {
        window.location.href = environment.urls.cexlApp;
    }

    onLoginStateChange({state, data}) {
        if (state === LoginStates.AttemptInProgress) {
            this.loader.setMessage('Logging you in...');
            this.loader.show();
            return;
        }

        data.credentialType = 'celigo-tba';

        data.user = {...data.user, email: this.userEmail};

        console.log('onLoginStateChange, event:', {state, data});

        if (state === LoginStates.Success) {
            this.storage.set('celigo_cexl_session_data', data);
            this.redirectToCEXLApp();
        }
    }

    onRemoveAllTokens(event) {
        this.router.navigate(['login', 'tba']);
    }
}
