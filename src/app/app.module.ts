// Angular
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

// Others
import { ClientAuthNetSuiteModule, AuthConfigService } from 'lib-client-auth-netsuite';

// Local - constants
import { environment } from './../environments/environment';

// Local - modules
import { AppRoutingModule } from './app-routing/app-routing.module';

// Local - services
import { LoaderService } from './loader.service';
import { OfficeService } from './office.service';
import { StorageService } from './storage.service';

// Local - components
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
    providers: [
        {provide: LocationStrategy, useClass: HashLocationStrategy},
        LoaderService,
        OfficeService,
        StorageService
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
    constructor(private authConfigService: AuthConfigService) {
        this.authConfigService.configure({
            baseUrl: environment.urls.authAPI.base,
            basicAuthRoute: environment.urls.authAPI.basicAuth,
            tbaAuthRoute: environment.urls.authAPI.tbaAuth
        });
    }
}
