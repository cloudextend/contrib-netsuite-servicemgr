import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';


@Component({
    selector: 'app-persist-tba-tokens',
    templateUrl: './persist-tba-tokens.component.html',
    styleUrls: ['./persist-tba-tokens.component.css']
})
export class PersistTbaTokensComponent implements OnInit {

    account: string;
    token: string;
    tokenSecret: string;

    constructor(
        private route: ActivatedRoute,
    ) { }

    ngOnInit() {
        this.account = this.route.snapshot.queryParams.account;
        this.token = this.route.snapshot.queryParams.token;
        this.tokenSecret = this.route.snapshot.queryParams.tokenSecret;
    }

    onTokenPersistStateChanged(event) {
        console.log(event);
    }
}
