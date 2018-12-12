import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';

import { environment } from '../../environments/environment';

@Component({
    selector: 'app-trial',
    templateUrl: './trial.component.html',
    styleUrls: ['./trial.component.css']
})
export class TrialComponent implements OnInit {

    constructor(
        private http: Http,
        private router: Router
    ) { }

    ngOnInit() { }

    onSignUp({
        data: { company, country, email, firstName, lastName, phone, state = '' }
    }) {

        const trialFormDetails = {
            firstName,
            lastName,
            trialEmail: email,
            company,
            phone,
            country,
            state,
            product: 'SCNS',
            plan_id: environment.cexlPlanID,
            eventType: 'created',
            eventSource: 'trial_form'
        };

        const {base, leadCreation} = environment.urls.backend;

        this.http.post(`${base}${leadCreation}`, trialFormDetails)
        .map(resp => resp.json())
        .subscribe(
            (response) => {
                this.router.navigate(['login', 'basic'], { queryParams: {isNewUser: true}});
            },
            error => { console.log('lead creation failed with error: ', error); }
        );
    }
}
