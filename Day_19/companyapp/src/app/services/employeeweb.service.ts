import { HttpClient, HttpHeaders } from "@angular/common/http";

import { Injectable } from "@angular/core";

import { Employee } from "../employee/employee";

 

@Injectable()

export class EmployeeWebService{

 

    constructor(private httpClient:HttpClient){

 

    }

    getToken():string{

        return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiQmFidSIsInJvbGUiOiJNYW5hZ2VyIiwibmJmIjoxNjk1Mjc5NzI3LCJleHAiOjE2OTUzNjYxMjcsImlhdCI6MTY5NTI3OTcyN30.VsPgFFi8I1l4XfjaeUcgphTxlE276axh4-XWajN8UM4";

    }

    getEmployees(){

        return this.httpClient.get("http://localhost:5159/api/Employee");

    }

 

    addEmployee(employee:Employee){

        const header = new HttpHeaders({

            'Content-Type':'application/json',

            'Authorization':'Bearer '+this.getToken()

        });

        console.log(employee);

        const requestOptions = {headers:header};

        return this.httpClient.post("http://localhost:5159/api/Employee",employee,requestOptions);

    }

 

    deleteEmployee(eid:number){

        const header = new HttpHeaders({

            'Content-Type':'application/json',

            'Authorization':'Bearer '+this.getToken()

        });

        console.log(eid);

        const requestOptions = {headers:header};

        return this.httpClient.put("http://localhost:5159/api/Employee/UpdateStatus?id="+eid,requestOptions);

    }

}
