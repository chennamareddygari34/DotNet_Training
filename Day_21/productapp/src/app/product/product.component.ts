import { Component } from '@angular/core';
import { Product } from './product';
import { ProductWebService } from '../services/productweb.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent {
  product:Product = new Product();
  className:string="";

  constructor(private productService:ProductWebService){
  
  }
  
  addProduct(){
    this.className= "spinner-border";
    this.productService.addProduct(this.product).subscribe(data=>{
      this.product = data as Product;
      if(this.product.id>0 && this.product.quantity!=0)
        alert("The product has been added");       
      else
        alert("Quantity can't be zero..");
        this.className= "";
    },
    (err)=>{
        console.log(err);
    })
    this.product = new Product();
  }
  changeId(eid:any){
    this.product.id=eid;
  }  
}
