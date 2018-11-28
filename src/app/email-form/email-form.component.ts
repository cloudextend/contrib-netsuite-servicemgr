import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { AuthUserPreferencesService, TokenService } from 'lib-client-auth-netsuite';

const loginMethodMap = {
    'celigo-basic': '/login/basic',
    'celigo-tba': '/login/tba',
    'celigo-sso': '/login/sso',
};

@Component({
    selector: 'app-email-form',
    templateUrl: './email-form.component.html',
    styleUrls: ['./email-form.component.css']
})
export class EmailFormComponent implements OnInit {
    @Input() email: string;

    userEmail = '';

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private userPreferenceService: AuthUserPreferencesService,
        private tokenService: TokenService,
    ) {}

    ngOnInit() {
        const clearEmail = this.route.snapshot.queryParams.clearEmail;

        if (clearEmail === 'true') {
            this.userPreferenceService.setDefaultEmail('');

            return;
        }

        if (!!this.userPreferenceService.getDefaultEmail()) {
            return this.goToNextRoute();
        }
    }

    private goToNextRoute() {
        const defaultMethod = this.userPreferenceService.getDefaultLoginMethod();

        const nextRoute = (defaultMethod === 'celigo-tba' && this.tokenService.hasSavedTokens())
            ? '/login/tba/unlock-tokens'
            : loginMethodMap[defaultMethod] || '/login';

        this.router.navigate([nextRoute]);
    }

    onContinue() {
        this.userPreferenceService.setDefaultEmail(this.userEmail);

        this.goToNextRoute();
    }
}
