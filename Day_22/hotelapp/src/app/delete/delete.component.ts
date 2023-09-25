import { Component } from '@angular/core';
import { Hotel } from '../hotel/hotel';
import { Router } from '@angular/router';
import { HotelService } from '../services/hotel.service';

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
    selectChange(hid:any){
      for (let index = 0; index < this.hotels.length; index++) {
        if(this.hotels[index].id==hid)
        {
          this.hotel= this.hotels[index];
          break;
        }
        
      }
    }
  
    deleteHotel(){
      this.hotelService.deleteHotel(this.hotel.id).subscribe(htl=>{
        if(htl){
          alert(" hotel deleted successfully")
          this.router.navigateByUrl("hotels");
        }
      })
      this.hotel = new Hotel();
    }
    // show(){
    //   this.router.navigateByUrl("delete/first")
    // }
  }


