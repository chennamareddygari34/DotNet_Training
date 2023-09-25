
import { Injectable } from "@angular/core";
import { Hotel } from "../hotel/hotel";
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable()
export class HotelService{
    hotels:Hotel[];
    constructor(private httpClient:HttpClient){
        this.hotels=[
          new Hotel(1,"Seasons","electronic city-1"),
          new Hotel(2,"Colors","electronic city-2")
        ];
      }

     

      getToken():string{
        var token = "";
        token = sessionStorage.getItem("token") as string;
        return token;

    }

      getHotels(){
       // return this.hotels;
       return this.httpClient.get("http://localhost:5268/api/Hotel");

      }

      addHotel(hotel:Hotel){
            const header = new HttpHeaders({
            'Content-Type':'application/json',
            'Authorization':'Bearer '+this.getToken()

        });

        console.log(hotel);
        const requestOptions = {headers:header};
        return this.httpClient.post("http://localhost:5268/api/Hotel",hotel,requestOptions);

    }

     


     deleteHotel(hid:number){
         const header = new HttpHeaders({
             'Content-Type':'application/json',
             'Authorization':'Bearer '+this.getToken()
         });
         console.log(hid);
         const requestOptions = {headers:header};
         return this.httpClient.delete("http://localhost:5268/api/Hotel?id="+hid,requestOptions);
     }

     updateHotel(hid:number){
        const header = new HttpHeaders({
            'Content-Type':'application/json',
            'Authorization':'Bearer '+this.getToken()
        });
        console.log(hid);
        const requestOptions = {headers:header};
        return this.httpClient.put("http://localhost:5268/api/Hotel/DeleteHotel?id="+hid,requestOptions);
    }

    }