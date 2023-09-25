import { Component } from '@angular/core';
import { Hotel } from '../hotel/hotel';
import { Router } from '@angular/router';
import { HotelService } from '../services/hotel.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent {

  hotel:Hotel= new Hotel();
  className:string="";
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

  updateHotel(){
    this.className= "spinner-border";
    this.hotelService.addHotel(this.hotel).subscribe(data=>{
      this.hotel = data as Hotel;
      if(this.hotel.id>0)
        alert("The hotel has been added");
        this.router.navigateByUrl("hotels");
    this.className="";
    },
    (err)=>{
        console.log(err);
    });

    alert("Hotel updated...");
    this.router.navigateByUrl("hotels");
    this.hotel = new Hotel();
  }
  changeId(hid:any){
    this.hotel.id=hid;
  }     
}
