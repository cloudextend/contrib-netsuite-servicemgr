import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './../login/login.component';
import { LoginTypesComponent } from './../login-types/login-types.component';
import { EmailFormComponent } from '../email-form/email-form.component';

const routes: Routes = [
    { path: '', component: EmailFormComponent },
    { path: 'login', component: LoginTypesComponent },
    { path: 'login/:type', component: LoginComponent }
];

@NgModule({
    imports: [ RouterModule.forRoot(routes) ],
    exports: [RouterModule]
})
export class AppRoutingModule {}
