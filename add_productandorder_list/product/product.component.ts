import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from '../services/product.service';
import { Product } from './product';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent {

  product:Product=new Product();
  className:string="";
  constructor(private productService:ProductService,private router:Router){
  }
  assignFile(pic:any){
    this.product.pic = "/assets/images/"+pic.files[0].name;
  }

  addProduct(){

  this.className= "spinner-border";

  this.productService.addProduct(this.product).subscribe(data=>{

    this.product = data as Product;

    if(this.product.id>0 )

    {

      alert("The product has been added");

      this.router.navigateByUrl("products");

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

  this.product = new Product();

}

changeId(hid:any){

  this.product.id=hid;

}    
}

