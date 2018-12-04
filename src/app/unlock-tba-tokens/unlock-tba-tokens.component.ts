import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { TbaPersistedStates } from 'lib-client-auth-netsuite';

@Component({
    selector: 'app-unlock-tba-tokens',
    templateUrl: './unlock-tba-tokens.component.html',
    styleUrls: ['./unlock-tba-tokens.component.css']
})
export class UnlockTbaTokensComponent implements OnInit {
    constructor(
        private router: Router
    ) { }

    ngOnInit() { }

    onTokenRetrievalStateChanged({state, inputs: {pin}}) {
        if (state !== TbaPersistedStates.HasSavedTokens) { return ; }

        this.router.navigate(['login', 'tba', 'list-tokens'], { queryParams: {pin} });
    }
}
