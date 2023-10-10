import { Component } from '@angular/core';
import { User } from '../models/user';
import { UserService } from '../services/userservice';
import { Router } from '@angular/router';
import jwtDecode from 'jwt-decode';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  user:User = new User();


  constructor(private userService:UserService,private router:Router){
  
  }
  
  loginClick(){
    this.userService.login(this.user).subscribe(  result=>{
      this.user = result as User;
      sessionStorage.setItem("token",this.user.token);
      const decodedToken:any = jwtDecode(this.user.token);
    
    console.log(decodedToken.name);
        alert("Login success");
        this.router.navigateByUrl("");
   
    },(error)=> {
    
     
      if (error.error && typeof error.error === 'string') {
        const errorMessage = error.error;
        alert(errorMessage); 
      } else {
       
        alert(JSON.stringify(error));
      }

     
    })
  }
  

}
