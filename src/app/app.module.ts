import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { LocalStorageModule } from '@ngx-pwa/local-storage';

import { ClientAuthNetSuiteModule, AuthConfigService } from 'lib-client-auth-netsuite';

import { AppRoutingModule } from './app-routing/app-routing.module';

import { StorageService } from './storage.service';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { LoginTypesComponent } from './login-types/login-types.component';
import { EmailFormComponent } from './email-form/email-form.component';

@NgModule({
    declarations: [
        AppComponent,
        LoginTypesComponent,
        LoginComponent,
        EmailFormComponent,
    ],
    imports: [
        AppRoutingModule,
        BrowserModule,
        ClientAuthNetSuiteModule,
        HttpClientModule,
        LocalStorageModule
    ],
    providers: [StorageService],
    bootstrap: [AppComponent]
})
export class AppModule {
    constructor(private authConfigService: AuthConfigService) {
        this.authConfigService.configure({
            baseUrl: 'https://00a817a2.ap.ngrok.io',
            basicAuthRoute: '/api/netsuite/2.0/auth',
            tbaAuthRoute: '/api/netsuite/2.0/auth'
        });
    }
}
