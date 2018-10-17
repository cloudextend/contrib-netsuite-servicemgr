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

    constructor(
        private route: ActivatedRoute,
        private http: Http
    ) {
        this.userEmail = this.route.snapshot.queryParams.email;
        this.http.get('https://00a817a2.ap.ngrok.io/api/netsuite/2.0/auth/type?' +
            `email=${this.route.snapshot.queryParams.email}`
        )
        .map(resp => resp.json())
        .subscribe(({ basic, tba, sso}) => {
            this.showBasic = basic;
            this.showTBA = tba;
            this.showSSO = sso;
        });
    }

    ngOnInit() {
    }
}
