import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from '../login/login.component';
import { LoginTypesComponent } from '../login-types/login-types.component';
import { EmailFormComponent } from '../email-form/email-form.component';
import { UnlockTbaTokensComponent } from '../unlock-tba-tokens/unlock-tba-tokens.component';
import { PersistTbaTokensComponent } from '../persist-tba-tokens/persist-tba-tokens.component';
import { ListTbaTokensComponent } from '../list-tba-tokens/list-tba-tokens.component';
import { WelcomeComponent } from '../welcome/welcome.component';

const routes: Routes = [
    { path: '', component: EmailFormComponent },
    { path: 'welcome', component: WelcomeComponent },
    { path: 'login', component: LoginTypesComponent },
    { path: 'login/:type', component: LoginComponent },
    { path: 'login/tba/unlock-tokens', component: UnlockTbaTokensComponent},
    { path: 'login/tba/persist-tokens', component: PersistTbaTokensComponent},
    { path: 'login/tba/list-tokens', component: ListTbaTokensComponent}
];

@NgModule({
    imports: [ RouterModule.forRoot(routes, {useHash: true}) ],
    exports: [RouterModule]
})
export class AppRoutingModule {}
