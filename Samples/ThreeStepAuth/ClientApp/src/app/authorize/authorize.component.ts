import { Component, OnInit } from '@angular/core';

import { AccessTokenResponse } from '../access-token-response';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-authorize',
    templateUrl: './authorize.component.html',
    styleUrls: ['./authorize.component.css']
})
export class AuthorizeComponent implements OnInit {

    public userToken: string;
    public userSecret: string;

    public state = "Authorizing...";

    constructor(private _http: HttpClient, private _activatedRoute: ActivatedRoute) {
    }

    ngOnInit() {
        const tokenSecret = sessionStorage.getItem("celigo_oauth_token_secret");
        const account = sessionStorage.getItem("celigo_account");

        const paramMap = this._activatedRoute.snapshot.queryParamMap;
        const url = "/api/tsa/authorized-token?"
            + `account=${account}`
            + `&requestToken=${paramMap.get("oauth_token")}`
            + `&tokenSecret=${tokenSecret}`
            + `&verifier=${paramMap.get("oauth_verifier")}`;

        this._http.get<AccessTokenResponse>(url)
            .subscribe(
                response => {
                    this.userToken = response.token;
                    this.userSecret = response.tokenSecret;

                    this.state = "Authorized";
                    console.log("Authorized Token Secret: " + this.userSecret);
                },
                error => {
                    console.error(error);
                    this.state = "Unauthorized";
                }
            )
    }
}
