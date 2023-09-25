import { Component } from '@angular/core';
import { Hotel } from './hotel';
import { Router } from '@angular/router';
import { HotelService } from '../services/hotel.service';

@Component({
  selector: 'app-hotel',
  templateUrl: './hotel.component.html',
  styleUrls: ['./hotel.component.css']
})
export class HotelComponent {
  hotel:Hotel = new Hotel();
  className:string="";
  constructor(private hotelService:HotelService,private router:Router){
  }

  addHotel(){
    this.className= "spinner-border";
    this.hotelService.addHotel(this.hotel).subscribe(data=>{
      this.hotel = data as Hotel;
      if(this.hotel.id>0 && this.hotel.hotelName!=null)
      {
        alert("The hotel has been added");
        this.router.navigateByUrl("hotels");
      }
      else{
        alert("Unable to add");
      }
    this.className="";
    },
    (err)=>{
        console.log(err);
    });

      alert("Check after the async")
    this.hotel = new Hotel();
  }
  changeId(hid:any){
    this.hotel.id=hid;
  }     
}
