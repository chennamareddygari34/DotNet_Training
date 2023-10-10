import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Hotel } from "../hotel/hotel";
import { Injectable } from "@angular/core";
import { Update } from "../update/update";

@Injectable()
export class HotelService{

    hotels:Hotel[];

    constructor(private httpClient:HttpClient){
        this.hotels=[
          new Hotel(1,"Seasons","Lake Side"),
          new Hotel(2,"Colors","Sea Side")
        ];
    }

    getToken():string{
        var token = "";
        token = sessionStorage.getItem("token") as string;
        return token;
    }

    getHotels(){
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

    deleteHotel(htl:number){
        const header = new HttpHeaders({
            'Content-Type':'application/json',
            'Authorization':'Bearer '+this.getToken()
        });
        console.log(htl);
        const requestOptions = {headers:header};
        return this.httpClient.delete("http://localhost:5268/api/Hotel?id="+htl,requestOptions);
    }

    // updateHotel(htl:number){
    //     const header = new HttpHeaders({
    //         'Content-Type':'application/json',
    //         'Authorization':'Bearer '+this.getToken()
    //     });
    //     console.log(htl);
    //     const requestOptions = {headers:header};
    //     return this.httpClient.put("http://localhost:5268/api/Hotel/Update",+htl,requestOptions);
    // }

    updateHotel(hotel:Update){
        const header = new HttpHeaders({
            'Content-Type':'application/json',
            'Authorization':'Bearer '+this.getToken()
        });
        console.log(hotel);
        const requestOptions = {headers:header};
        return this.httpClient.put("http://localhost:5268/api/Hotel/Update",hotel,requestOptions);
    }
}