import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Product } from "../product/product";


@Injectable()
export class ProductService{
    products:Product[];
    constructor(private httpClient:HttpClient){
        this.products =[
          
        ];
      }
      getProducts(){
        return this.httpClient.get("http://localhost:5158/api/Product");
      }

      addProduct(product:Product){

      
        console.log(product);


        return this.httpClient.post("http://localhost:5158/api/Product",product);

    }


      getProduct(eid:number):any{
        var eidx:number=-1;
        for (let index = 0; index < this.products.length; index++) {
                if(this.products[index].id==eid)
                {
                    eidx = index;
                    break;
                }
        }
        if(eidx != -1)
            return this.products[eidx];
      }
}
 

