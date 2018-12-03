import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { StorageService } from '../storage.service';

@Component({
    selector: 'app-welcome',
    templateUrl: './welcome.component.html',
    styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {

    constructor(
        private router: Router,
        private storage: StorageService
    ) { }

    ngOnInit() { }

    onContinue() {
        this.storage.set('celigo_user_welcomed', true);

        this.router.navigate(['']);

        return;
    }
}
