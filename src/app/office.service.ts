import { Injectable } from '@angular/core';

@Injectable()
export class OfficeService {
    private office;

    constructor() {
        // if ( !window.hasOwnProperty( 'Office' ) ) {
        //     throw new Error( 'Unable to find the Office API' );
        // }

        this.office = ( <any>window ).Office;
    }

    public openDialog( url: string, callback: Function ): void {
        this.office.context.ui.displayDialogAsync( url, ( res: any ) => {
            const dialog = res.value;
            dialog.addEventHandler( this.office.EventType.DialogMessageReceived, callback );
        } );
    }
}
