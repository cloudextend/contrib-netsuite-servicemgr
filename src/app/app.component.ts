import { Component, OnInit } from '@angular/core';
import { LoaderService } from './loader.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    title = 'CloudExtend Excel for NetSuite';
    showLoader = false;
    loadingMessage = 'testing';

    constructor(
        private loader: LoaderService
    ) {}

    ngOnInit() {
        this.loader.isLoading.subscribe(isLoading => this.showLoader = isLoading);
        this.loader.loadingMessage.subscribe(message => this.loadingMessage = message);
    }
}
