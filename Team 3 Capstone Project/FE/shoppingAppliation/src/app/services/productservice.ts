import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { CartItems } from "../models/cart";

import { Product } from "../models/Product";
import { OrderRequestDto } from "../models/OrderRequestDto";

@Injectable()
export class Productservice{



    constructor(private httpclient:HttpClient){

    }

    getToken():string{
        var key="";
          key=sessionStorage.getItem("token") as string;
          return key;
      }

    
      DeleteByCartId(id:any){
      

        return this.httpclient.delete("http://localhost:5158/api/TempCart?cartId="+id);
    }


    getByCartId(id:any){
      console.log(id)

        return this.httpclient.get("http://localhost:5158/api/TempCart/GetById?orderId="+id);
    }


    updatetempcart(cart:CartItems){
      console.log(cart)

        return this.httpclient.put("http://localhost:5158/api/TempCart/UpdateCartItem",cart);
    }


    orderItem(cart:OrderRequestDto){
      console.log(cart)

        return this.httpclient.post("http://localhost:5158/api/Order",cart);
    }

    getCartItems(){
      
        return this.httpclient.get("http://localhost:5158/api/TempCart");
    }


    getProduct(){
      return this.httpclient.get("http://localhost:5158/api/Product");
  }

  localAddToCart(data:Product){

      let cartData=[];
      let localCart1=localStorage.getItem('localCart');

      if(!localCart1)
      {
          localStorage.setItem('localCart',JSON.stringify([data]));

      }
      else{
        
          cartData=JSON.parse(localCart1);
    
          cartData.push(data)
          localStorage.setItem('localCart',JSON.stringify(cartData));
      }

  }

  AddtoCart(cart:CartItems){
      return this.httpclient.post("http://localhost:5158/api/TempCart",cart);
  }

  addProduct(product:Product){

      console.log(product);

      return this.httpclient.post("http://localhost:5158/api/Product",product);



  }


}