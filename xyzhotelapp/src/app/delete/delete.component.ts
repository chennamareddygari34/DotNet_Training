import { Component } from '@angular/core';
import { Hotel } from '../hotel/hotel';
import { HotelService } from '../services/hotel.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent {
  hotel:Hotel= new Hotel();
  hotels:Hotel[]=[];
  constructor(private hotelService:HotelService,private router:Router){
    this.hotelService.getHotels().subscribe(htl=>{
      this.hotels = htl as Hotel[];
    })
  }

  selectChange(htl:any){
    for (let index = 0; index < this.hotels.length; index++) {
      if(this.hotels[index].id==htl)
      {
        this.hotel = this.hotels[index];
        break;
      }
    }
  }

  deleteHotel(){
    this.hotelService.deleteHotel(this.hotel.id).subscribe(htl=>{
      if(htl){
        alert("Hotel deleted...");
        this.router.navigateByUrl("hotels");
      }
    })
    this.hotel = new Hotel();
  }
  back(){
    this.router.navigateByUrl("home");
  }
  cancel(){
    this.router.navigateByUrl("home");
  }

}
