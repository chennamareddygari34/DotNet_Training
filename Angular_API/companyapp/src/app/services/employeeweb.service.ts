import { HttpClient, HttpHeaders } from "@angular/common/http";

import { Injectable } from "@angular/core";

import { Employee } from "../employee/employee";

 

@Injectable()

export class EmployeeWebService{

 

    constructor(private httpClient:HttpClient){

 

    }

    getToken():string{

        return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoic2hhaGFuYWoiLCJyb2xlIjoiTWFuYWdlciIsIm5iZiI6MTY5NTE5MTkyOCwiZXhwIjoxNjk1Mjc4MzI4LCJpYXQiOjE2OTUxOTE5Mjh9.TX4G7COXZxbmvSRkNMBCBdOn5S-bUifnfzfcXHu9uXU";

    }

    getEmployees(){

        return this.httpClient.get("http://localhost:5210/api/Employee");

    }

 

    addEmployee(employee:Employee){

        const header = new HttpHeaders({

            'Content-Type':'application/json',

            'Authorization':'Bearer '+this.getToken()

        });

        console.log(employee);

        const requestOptions = {headers:header};

        return this.httpClient.post("http://localhost:5210/api/Employee",employee,requestOptions);

    }

 

    deleteEmployee(eid:number){

        const header = new HttpHeaders({

            'Content-Type':'application/json',

            'Authorization':'Bearer '+this.getToken()

        });

        console.log(eid);

        const requestOptions = {headers:header};

        return this.httpClient.put("http://localhost:5210/api/Employee/UpdateStatus?id="+eid,requestOptions);

    }

}
