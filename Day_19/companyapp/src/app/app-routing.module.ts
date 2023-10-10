

import { NgModule } from '@angular/core';

import { RouterModule, Routes } from '@angular/router';

import { SecondComponent } from './second/second.component';

import { EmployeeComponent } from './employee/employee.component';

import { DeleteEmpComponent } from './delete-emp/delete-emp.component';

import { EmployeesComponent } from './employees/employees.component';

import { LoginComponent } from './login/login.component';

import { FirstComponent } from './first/first.component';


import { OneComponent } from './one/one.component';

import { TwoComponent } from './two/two.component';

import { UpdateEmployeeComponent } from './update-employee/update-employee.component';
import { AuthGuard } from './services/auth.service';

 

const routes: Routes = [

  {path:'home',component:SecondComponent},

  {path:'employees',component:EmployeesComponent},

  {path:'add',component:EmployeeComponent,canActivate:[AuthGuard]},

  {path:'delete',component:DeleteEmpComponent,children:[

 

    {path:'first',component:FirstComponent }

]},

  {path:'login',component:LoginComponent},

  {path:'one',component:OneComponent},

  {path:'two/:g3',component:TwoComponent},

  {path:'update/:eid',component:UpdateEmployeeComponent}

];

 

@NgModule({

  imports: [RouterModule.forRoot(routes)],

  exports: [RouterModule]

})

export class AppRoutingModule { }

 