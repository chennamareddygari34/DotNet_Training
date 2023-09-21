import { Component } from '@angular/core';
import { Product } from '../product/product';
import { ProductWebService } from '../services/productweb.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent {
  products:Product[]=[];
  
  constructor(private productService:ProductWebService){
    this.productService.getProducts().subscribe(data=>{
      console.log(data)
      this.products = data as Product[];
    })
  }
}
