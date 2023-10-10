import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Hotel } from "../hotel/hotel";
import { Injectable } from "@angular/core";
import { Update } from "../update/update";
import { Room } from "../room/room";import { UpdateRoom } from "../updateroom/updateroom";

@Injectable()
export class RoomService{

    rooms:Room[];

    constructor(private httpClient:HttpClient){
        this.rooms=[
          new Room(1,"Single","true",25000),
          new Room(2,"Double","false",20000)
        ];
    }

    getToken():string{
        var token = "";
        token = sessionStorage.getItem("token") as string;
        return token;
    }

    getRooms(){
        return this.httpClient.get("http://localhost:5268/api/Room");
       }

    addRoom(room:Room){
        const header = new HttpHeaders({
            'Content-Type':'application/json',
            'Authorization':'Bearer '+this.getToken()
        });
        console.log(room);
        const requestOptions = {headers:header};
        return this.httpClient.post("http://localhost:5268/api/Room",room,requestOptions);
    }

    // deleteHotel(htl:number){
    //     const header = new HttpHeaders({
    //         'Content-Type':'application/json',
    //         'Authorization':'Bearer '+this.getToken()
    //     });
    //     console.log(htl);
    //     const requestOptions = {headers:header};
    //     return this.httpClient.delete("http://localhost:5268/api/Hotel?id="+htl,requestOptions);
    // }

    // updateHotel(htl:number){
    //     const header = new HttpHeaders({
    //         'Content-Type':'application/json',
    //         'Authorization':'Bearer '+this.getToken()
    //     });
    //     console.log(htl);
    //     const requestOptions = {headers:header};
    //     return this.httpClient.put("http://localhost:5268/api/Hotel/Update",+htl,requestOptions);
    // }

    updateRoom(room:UpdateRoom){
        const header = new HttpHeaders({
            'Content-Type':'application/json',
            'Authorization':'Bearer '+this.getToken()
        });
        console.log(room);
        const requestOptions = {headers:header};
        return this.httpClient.put("http://localhost:5268/api/Room",room,requestOptions);
    }

    deleteRoom(htl:number){
        const header = new HttpHeaders({
            'Content-Type':'application/json',
            'Authorization':'Bearer '+this.getToken()
        });
        console.log(htl);
        const requestOptions = {headers:header};
        return this.httpClient.delete("http://localhost:5268/api/Room?id="+htl,requestOptions);
    }
}