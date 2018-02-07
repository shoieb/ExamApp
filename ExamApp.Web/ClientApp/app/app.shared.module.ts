import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { addemployeeComponent } from './components/employee/employee.add.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { EmployeeService } from './components/employee/employee.service';
import { UserService } from './components/user/user.service';
import { userLoginComponent } from './components/user/user.login.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        EmployeeComponent,
        addemployeeComponent,
        userLoginComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'login', pathMatch: 'full' },
            { path: 'login', component: userLoginComponent },
            { path: 'employee', component: EmployeeComponent },
            { path: 'add-employee', component: addemployeeComponent },
            { path: 'edit-employee/:id', component: addemployeeComponent },
            { path: '**', redirectTo: 'login' }
        ])
    ],
    providers: [EmployeeService, UserService]
})

export class AppModuleShared {
}
