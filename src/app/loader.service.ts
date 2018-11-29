import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class LoaderService {
    public isLoading: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
    public loadingMessage: BehaviorSubject<string> = new BehaviorSubject<string>('Loading...');

    showLoader(shouldShow) {
        this.isLoading.next(shouldShow);
    }

    setLoadingMessage(loadingMessage) {
        this.loadingMessage.next(loadingMessage);
    }
}
