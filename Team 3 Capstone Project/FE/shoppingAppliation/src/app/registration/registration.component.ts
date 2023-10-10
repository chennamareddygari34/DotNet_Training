import { Component } from '@angular/core';
import { User } from '../models/user';
import { UserService } from '../services/userservice';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  user:User = new User();


  constructor(private userService:UserService,private router:Router){
  
  }
  
  Register(){
    this.userService.register(this.user).subscribe(result=>{
      this.user = result as User;
      if(result!=null){
        alert(" Congrats Registration successfull Please log in first")
      }
     
    })
this.router.navigateByUrl("login")
}

}
