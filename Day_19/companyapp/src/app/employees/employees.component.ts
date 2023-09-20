import { Component } from '@angular/core';
import { Employee } from '../employee/employee';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent {
  employees:Employee[]=[];
  
  constructor(private employeeService:EmployeeService){
    this.employees = this.employeeService.getEmployees();
  }

}
