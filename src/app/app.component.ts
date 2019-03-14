import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
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
        private changeDetector: ChangeDetectorRef,
        private loader: LoaderService
    ) {}

    ngOnInit() {
        this.loader.loadingState.subscribe(isLoading => {
            this.showLoader = isLoading;

            // Force the re-render using changeDetector in favor of lib components. Check HYSC-1753
            this.changeDetector.detectChanges();
        });

        this.loader.loadingMessage.subscribe(message => {
            this.loadingMessage = message;

            // Force the re-render using changeDetector in favor of lib components. Check HYSC-1753
            this.changeDetector.detectChanges();
        });
    }
}
