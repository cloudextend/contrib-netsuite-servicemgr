import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { ClientAuthNetSuiteModule, AuthConfigService } from 'lib-client-auth-netsuite';

import { AppRoutingModule } from './app-routing/app-routing.module';

import { OfficeService } from './office.service';
import { StorageService } from './storage.service';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { LoginTypesComponent } from './login-types/login-types.component';
import { EmailFormComponent } from './email-form/email-form.component';
import { UnlockTbaTokensComponent } from './unlock-tba-tokens/unlock-tba-tokens.component';
import { PersistTbaTokensComponent } from './persist-tba-tokens/persist-tba-tokens.component';
import { ListTbaTokensComponent } from './list-tba-tokens/list-tba-tokens.component';
// import { NgMaterialModule } from './ng-material/ng-material.module';

@NgModule({
    declarations: [
        AppComponent,
        LoginTypesComponent,
        LoginComponent,
        EmailFormComponent,
        UnlockTbaTokensComponent,
        PersistTbaTokensComponent,
        ListTbaTokensComponent,
    ],
    imports: [
        AppRoutingModule,
        BrowserModule,
        ClientAuthNetSuiteModule,
        FormsModule,
        HttpClientModule,
        // NgMaterialModule
    ],
    providers: [OfficeService, StorageService],
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
