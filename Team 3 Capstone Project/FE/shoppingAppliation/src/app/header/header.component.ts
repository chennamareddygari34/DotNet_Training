import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '../models/Product';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  islogin:boolean=false;
  totalItem:number=0;

  constructor(private router:Router){
    var data=sessionStorage.getItem("token");
    if(data!=null){
      this.islogin=true;
    }
    let localCartString = localStorage.getItem('localCart');
    if (localCartString) {

      let localCartArray = JSON.parse(localCartString);
      
    const uniqueIds = new Set(localCartArray.map((item:Product) => item.id));
    const uniqueIdArray = Array.from(uniqueIds);
    console.log(uniqueIdArray);
    this.totalItem=uniqueIdArray.length;

    }
  }

  logout(){
    
    
    sessionStorage.removeItem("token");
  
       
       this.router.navigate([""]);
       this.islogin=false;
 
   }
 

}
