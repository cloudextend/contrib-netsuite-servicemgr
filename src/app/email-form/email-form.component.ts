import { Component, OnInit, Input, Output } from '@angular/core';
import { EventEmitter } from 'events';

@Component({
    selector: 'app-email-form',
    templateUrl: './email-form.component.html',
    styleUrls: ['./email-form.component.css']
})
export class EmailFormComponent implements OnInit {
    @Input() userEmail = 'someone@somewhere.com';

    constructor() { }

    ngOnInit() { }
}
