import { Component } from '@angular/core';
import { Product } from '../models/Product';
import { Productservice } from '../services/productservice';
import { Router } from '@angular/router';

@Component({
  selector: 'app-addproduct',
  templateUrl: './addproduct.component.html',
  styleUrls: ['./addproduct.component.css']
})
export class AddproductComponent {
  product:Product=new Product();

  className:string="";

  constructor(private productService:Productservice,private router:Router){

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

      this.router.navigateByUrl("");

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
