import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Product } from "../product/product";

@Injectable()
export class ProductWebService{

    constructor(private httpClient:HttpClient){

    }
    getProducts(){
        return this.httpClient.get("http://localhost:5100/api/Product");
    }

    addProduct(product:Product){
        const header = new HttpHeaders({
            'Content-Type':'application/json'
        });
        console.log(product);
        const requestOptions = {headers:header};
        return this.httpClient.post("http://localhost:5100/api/Product",product,requestOptions);
    }
}