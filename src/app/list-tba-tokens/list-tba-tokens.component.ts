import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-list-tba-tokens',
    templateUrl: './list-tba-tokens.component.html',
    styleUrls: ['./list-tba-tokens.component.css']
})
export class ListTbaTokensComponent implements OnInit {
    pin: string;

    constructor(
        private route: ActivatedRoute
    ) { }

    ngOnInit() {
        this.pin = this.route.snapshot.queryParams.pin;
    }

    onLoginStateChange(event) {
        console.log(event);
    }
}
