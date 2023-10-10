import { Component } from '@angular/core';
import { ProductService } from '../services/product.service';
import { Product } from '../product/product';
import { Router } from '@angular/router';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent {
  products:Product[]=[];
 product:Product = new Product();
  
  constructor(private productService:ProductService,private router:Router){
    this.productService.getProducts().subscribe(data=>{
      console.log(data)
      this.products = data as Product[];
    })
  }
  showProducts(){
    this.router.navigateByUrl("products");
  }
}


