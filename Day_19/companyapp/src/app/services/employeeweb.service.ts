import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class EmployeeWebService{

    constructor(private httpCLient:HttpClient){

    }

    getEmployees(){
        return this.httpCLient.get("http://localhost:5159/api/Employee");
    }
}