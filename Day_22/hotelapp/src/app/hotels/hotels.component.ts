import { Component } from '@angular/core';
import { Hotel } from '../hotel/hotel';
import { HotelService } from '../services/hotel.service';

@Component({
  selector: 'app-hotels',
  templateUrl: './hotels.component.html',
  styleUrls: ['./hotels.component.css']
})
export class HotelsComponent {



    hotels:Hotel[]=[];
    
    constructor(private hotelService:HotelService){
      this.hotelService.getHotels().subscribe(data=>{
        console.log(data)
        this.hotels = data as Hotel[];      })
    }
}
