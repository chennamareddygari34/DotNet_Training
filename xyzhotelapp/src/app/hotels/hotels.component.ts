import { Component } from '@angular/core';
import { Hotel } from '../hotel/hotel';
import { HotelService } from '../services/hotel.service';
import { Router } from '@angular/router';

 

@Component({
  selector: 'app-hotels',
  templateUrl: './hotels.component.html',
  styleUrls: ['./hotels.component.css']
})

export class HotelsComponent {
    hotels:Hotel[]=[];
    constructor(private hotelService:HotelService, private router:Router){
      this.hotelService.getHotels().subscribe(data=>{
        console.log(data)
        this.hotels = data as Hotel[];     
       })
    }

    showRooms(){
      this.router.navigateByUrl("rooms");
    }
    back(){
      this.router.navigateByUrl("home");
    }
}

 