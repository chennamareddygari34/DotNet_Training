import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "../models/user";

@Injectable()
export class UserService{
    constructor(private httpClient:HttpClient){

    }
    login(user:User){
       return this.httpClient.post("http://localhost:5158/api/User/Login",user);
    }

    register(user:User){
        return this.httpClient.post("http://localhost:5158/api/User/Register",user);
     }

     Getaddress(username:any){
      return this.httpClient.get("http://localhost:5158/api/UserAddress/getAddressByUsername?username="+username);
   }


     
}