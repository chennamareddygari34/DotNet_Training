import { Injectable } from "@angular/core";
import { Order } from "../order/order";
import { HttpClient } from "@angular/common/http";
@Injectable()

export class OrderService{
  orders:Order[];
    constructor(private httpClient:HttpClient){
        this.orders =[
          
        ];
      }
      getOrders(){
        return this.httpClient.get("http://localhost:5158/api/Order");
      }

      addOrder(order:Order){

       // const header = new HttpHeaders({

            //'Content-Type':'application/json',

           // 'Authorization':'Bearer '+this.getToken()

       // });

        console.log(order);

       // const requestOptions = {headers:header};

        return this.httpClient.post("http://localhost:5158/api/Order",order);

    }


      deleteOrder(eid:number){
        var eidx;
        for (let index = 0; index < this.orders.length; index++) {
                if(this.orders[index].id==eid)
                {
                    eidx = index;
                    break;
                }
        }
        console.log(this.orders[eidx??0]);
        this.orders.splice(eidx??-1,1)
      }

      getOrder(eid:number):any{
        var eidx:number=-1;
        for (let index = 0; index < this.orders.length; index++) {
                if(this.orders[index].id==eid)
                {
                    eidx = index;
                    break;
                }
        }
        if(eidx != -1)
            return this.orders[eidx];
      }
}
 

