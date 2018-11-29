import { Component } from '@angular/core';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    title = 'CloudExtend Excel for NetSuite';

    load = true;

    loadingMessage = 'testing';
}
