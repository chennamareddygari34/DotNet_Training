import { Component, OnInit } from '@angular/core';
import { CartItems } from '../models/cart';
import { Productservice } from '../services/productservice';
import { Router } from '@angular/router';
import { OrderRequestDto } from '../models/OrderRequestDto';
import jwtDecode from 'jwt-decode';
import { UserService } from '../services/userservice';
import { UserAddress } from '../models/useraddress';
import { OrderResponseDto } from '../models/orderresponsedto';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent  {
  carts:CartItems[]=[];
  hotelId:number=0;
  islogin:string="";
  quantityCounter: number = 1;
  destinationList:any[]=[];
  isAddressselected:boolean=false;
  address:UserAddress=new UserAddress()
  orderitem:OrderRequestDto= new OrderRequestDto;
  orderconfirmeitem:OrderResponseDto=new OrderResponseDto();
  
  constructor(private productservice:Productservice,private router:Router,private userservice:UserService){
    
   this.productservice.getCartItems().subscribe(data=>{
   

    this.carts=data as CartItems[];
    // this.checkLoginStatus();
   })

 
  
  }

  getAddress(): void {
    const data:any=sessionStorage.getItem("token")
    let decodetoken:any=jwtDecode(data)
    if(decodetoken.name!=null){
      this.isAddressselected=true;
    this.userservice.Getaddress(decodetoken.name).subscribe(data=>{
    
  
      this.address=data as UserAddress;

     
      // this.checkLoginStatus();
     })

    }else{
      alert("login First")
      this.router.navigate(["login"])
    }

     
  }


  details(cId:any){
    this.router.navigate(["cartdetail",cId])

  }

  increaseQuantity() {
    this.quantityCounter++;
   
  }

  decreaseQuantity() {
    if (this.quantityCounter > 1) {
      this.quantityCounter--;
     
    }
  }

OrderItems() {
  const data: any = sessionStorage.getItem("token");

  if (data != null) {
    if (this.address != null) {
      const decodedToken: any = jwtDecode(data);
      const username = decodedToken.name;
      let totalPrice = this.carts.reduce((sum, obj) => sum + obj.productTotalPrice, 0);
      let uniqueProductIds: Set<number> = new Set(this.carts.map((item: CartItems) => item.productId));
      let totalQuantity: number = uniqueProductIds.size;

      this.orderitem.totalPrice = totalPrice;
      this.orderitem.totalProductQuantity = totalQuantity;
      this.orderitem.username = username;
      this.orderitem.addressId = this.address.id;
      this.orderitem.listofItems = this.carts;

      this.productservice.orderItem(this.orderitem).subscribe(data => {
        console.log(data);

        if (data != null) {
          alert("Your order Is placed");
          localStorage.removeItem("localCart");
          this.orderconfirmeitem = data as OrderResponseDto;

        }
      });

    } else {
      alert("Please select address first ):");
    }
  } else {
    alert("Please Log-in first ):");
    this.router.navigate(["login"]);
  }
}


  RemoveItem(cId:any){

   
   this.productservice.DeleteByCartId(cId).subscribe(data=>{
   
  if(data!=null){

    alert("item Removed from Your Cart")
  }

   })

  }


}
