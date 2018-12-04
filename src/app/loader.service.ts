import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class LoaderService {
    public loadingState: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
    public loadingMessage: BehaviorSubject<string> = new BehaviorSubject<string>('Loading...');

    show() {
        setTimeout(() => { this.loadingState.next(true); }, 0);
    }

    hide() {
        setTimeout(() => { this.loadingState.next(false); }, 0);
    }

    setMessage(loadingMessage = 'Loading...') {
        setTimeout(() => { this.loadingMessage.next(loadingMessage); }, 0);
    }
}
