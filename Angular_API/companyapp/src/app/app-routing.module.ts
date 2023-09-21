import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SecondComponent } from './second/second.component';
import { EmployeeComponent } from './employee/employee.component';
import { DeleteEmpComponent } from './delete-emp/delete-emp.component';
import { EmployeesComponent } from './employees/employees.component';

const routes: Routes = [
    {path: 'home', component: SecondComponent},
    {path: 'employees',component:EmployeesComponent},
    {path: 'add', component: EmployeeComponent},
    {path: 'delete', component:DeleteEmpComponent } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
