import { Component } from '@angular/core';
import { CartItems } from '../models/cart';
import { Productservice } from '../services/productservice';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-cartitemdetail',
  templateUrl: './cartitemdetail.component.html',
  styleUrls: ['./cartitemdetail.component.css']
})
export class CartitemdetailComponent {


  
  cart:CartItems=new CartItems();
  quantityCounter: number = 1;
  pricePerItem: number = this.cart.productPrice; // Set your price here
  total: number = 1;
  cartId:number=0;

  constructor(private productservice:Productservice,private routeactive:ActivatedRoute,private router:Router){
    this.cartId = routeactive.snapshot.params["cId"]
    this.productservice.getByCartId(this.cartId).subscribe(data=>{
    
        this.cart=data as CartItems;
    })
  }


  increaseQuantity() {
    this.quantityCounter++;
  
  }

  decreaseQuantity() {
    if (this.quantityCounter > 1) {
      this.quantityCounter--;
   
    }
  }


Updatecart(total:any){
  this.cart.productTotalPrice=total;
  this.cart.productQuantity=this.quantityCounter;

 this.productservice.updatetempcart(this.cart).subscribe(data=>{

    this.cart=data as CartItems;

  })
this.router.navigateByUrl("cart")

}

}
