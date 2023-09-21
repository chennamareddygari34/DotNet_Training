
import { Component } from '@angular/core';
import { Employee } from './employee';

import { EmployeeWebService } from '../services/employeeweb.service';

import { Router } from '@angular/router';

//import { EmployeeWebService } from '../Services/employeeweb.service';
@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent {
  employee:Employee = new Employee();
  className:string="";
  constructor(private employeeService:EmployeeWebService,private router:Router){
  }
  addEmployee(){
    this.className= "spinner-border";
    // this.employeeService.addEmployee(this.employee);
    this.employeeService.addEmployee(this.employee).subscribe(data=>{
      this.employee = data as Employee;

      if(this.employee.id>0)

      {

        alert("The emloyee has been added");

        this.router.navigateByUrl("employees");

      }

      else

      alert("Sorry,unable to add at this moment")

    this.className="";
      // if(this.employee.id>0)

 

      //   alert("The emloyee has been added");

 

      //   this.className= "";

    },
    (err)=>{

        console.log(err);
    });

      alert("Check after the async")

    this.employee = new Employee();
  }
  changeId(eid:any){
    this.employee.id=eid;
  }  
}