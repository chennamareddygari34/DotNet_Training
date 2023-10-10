

import { Component } from '@angular/core';

import { Order } from './order';

import { Router } from '@angular/router';

import { OrderService } from '../services/order.service';

 

@Component({

  selector: 'app-order',

  templateUrl: './order.component.html',

  styleUrls: ['./order.component.css']

})

export class OrderComponent {
  order:Order = new Order();
  className:string="";
  constructor(private orderService:OrderService,private router:Router){
  }
//   addOrder(){
//     this.className= "spinner-border";
//     this.orderService.addOrder(this.order);

//     // this.orderService.addOrder(this.order).subscribe(data=>{
//      // this.order = data as Order;

//       if(this.order.id>0)

//       {

//         alert("The order has been added");

//         this.router.navigateByUrl("orders");

//       }

//       // else

//       // alert("Sorry,unable to add at this moment")

//     this.className="";
//       // if(this.employee.id>0)

 

//       //   alert("The emloyee has been added");

 

//       //   this.className= "";

//     },
//     (err:any)=>{

//         alert("unable to add");
//     });

//       alert("Check after the async")

//     this.order = new Order();
//   }
//   changeId(eid:any){
//     this.order.id=eid;
//   }  

addOrder(){

  this.className= "spinner-border";

  this.orderService.addOrder(this.order).subscribe(data=>{

    this.order = data as Order;

    if(this.order.id>0)

    {

      alert("The order has been added");

      this.router.navigateByUrl("orders");

    }

    else{

      alert("Unable to add");

    }

  this.className="";

  },

  (err:any)=>{

      console.log(err);

  });



    alert("Check after the async")

  this.order = new Order();

}

changeId(hid:any){

  this.order.id=hid;

}    
}
