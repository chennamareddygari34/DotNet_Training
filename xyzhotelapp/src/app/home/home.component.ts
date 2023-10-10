import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  constructor(private router:Router){
  }
  hotels(){
    this.router.navigateByUrl("hotels");
  }
  add(){
    this.router.navigateByUrl("add");
  }
  delete(){
    this.router.navigateByUrl("delete");
  }
  update(){
    this.router.navigateByUrl("update");
  }
  logout(){
    sessionStorage.removeItem("token");
    this.router.navigateByUrl("login");
  }
}
