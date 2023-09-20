import { Component } from '@angular/core';
import { Employee } from './employee';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent {
employee:Employee = new Employee()


constructor(private employeeService:EmployeeService){
  
}

addEmployee(){
  this.employeeService.addEmployee(this.employee);
  this.employee = new Employee();
}
changeId(eid:any){
  this.employee.id=eid;
}
}