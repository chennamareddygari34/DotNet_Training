import { Component } from '@angular/core';
import { Product } from '../models/Product';
import { CartItems } from '../models/cart';
import { Productservice } from '../services/productservice';
import { Router } from '@angular/router';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent {

isclicked:boolean=false;

  products:Product[]=[];
  localIds:Product[]=[];
  removeCart=false;
  public searchKey:string ="";
  cart:CartItems= new CartItems();
  public totalItem : number = 0;


  
  constructor(private productService:Productservice,private router:Router){
    

    this.productService.getProduct().subscribe(data=>{
   
      this.products = data as Product[];
    })
    
  }

   

  BuyClick(selectedproduct:any){
    const data: any = sessionStorage.getItem("token");
    if(data !=null){
      if(this.isclicked==false){
        this.AddToCart(selectedproduct)
        this.isclicked=true;
        }
      
      this.router.navigateByUrl("cart")
    }else{
      this.router.navigateByUrl("login")
    }
    
  }

  AddToCart(selectedproduct:any){
   
   
     
    
      this.cart.productId=selectedproduct.id;
      this.cart.productName=selectedproduct.name;
      this.cart.productPrice=selectedproduct.price;
      this.cart.productQuantity=1;
      this.cart.proPic=selectedproduct.pic;
      this.cart.productTotalPrice=selectedproduct.price;

    this.productService.AddtoCart(this.cart).subscribe(data=>{
      this.cart=data as CartItems;
      if(this.cart.id>0){
        alert("product add to cart")
       
      }
    })
  
 
   
    this.productService.localAddToCart(selectedproduct); 
    this.removeCart=true;
    let localCartString = localStorage.getItem('localCart');
    if (localCartString) {

      let localCartArray = JSON.parse(localCartString);
      
    const uniqueIds = new Set(localCartArray.map((item:Product) => item.id));
    const uniqueIdArray = Array.from(uniqueIds);
    console.log(uniqueIdArray);
    this.totalItem=uniqueIdArray.length;
  
   
    } else {
      console.log('No data found in local storage');
    }
          
   
  }

}
