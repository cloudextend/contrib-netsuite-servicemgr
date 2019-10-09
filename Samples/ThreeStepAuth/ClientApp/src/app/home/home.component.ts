import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { RequestTokenRespone } from '../request-token-response';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent {

    public accountNumber: string;
    public loginForm;

    constructor(private _formBuilder: FormBuilder, private _http: HttpClient) {
        this.loginForm = this._formBuilder.group({ account: '' });
    }

    public onLogin(loginData) {
        sessionStorage.clear();

        const account = loginData.account;
        console.log(`Logging in to ${account}...`);

        const callbakUrl = encodeURIComponent(`${window.location.href}authorize`);

        this._http.get<RequestTokenRespone>(`/api/tsa/request-token?account=${account}&callbackUrl=${callbakUrl}`)
            .subscribe(
                response => {
                    console.log(response);

                    sessionStorage.setItem("celigo_oauth_token_secret", response.tokenSecret);
                    sessionStorage.setItem("celigo_account", account);

                    window.location.href = `https://${account}.app.netsuite.com/app/login/secure/authorizetoken.nl?oauth_token=${response.token}&state=${response.tokenSecret}`;
                },
                error => {
                    console.error(error);
                }
            );
    }
}
