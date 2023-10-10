import { Component } from '@angular/core';
import { Hotel } from '../hotel/hotel';
import { HotelService } from '../services/hotel.service';
import { Router } from '@angular/router';
import { Update } from './update';

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

  selectChange(htl:any){
    for (let index = 0; index < this.hotels.length; index++) {
      if(this.hotels[index].id==htl)
      {
        this.hotel = this.hotels[index];
        break;
      }
    }
  }

  // updateHotel(){
  //   this.className= "spinner-border";
  //   this.hotelService.addHotel(this.hotel).subscribe(data=>{
  //     this.hotel = data as Hotel;
  //     if(this.hotel.id>0)
  //       this.router.navigateByUrl("hotels");
  //   this.className="";
  //   },
  //   (err)=>{
  //       console.log(err);
  //   });

  //   alert("Hotel updated...");
  //   this.router.navigateByUrl("hotels");
  //   this.hotel = new Hotel();
  // }
  // changeId(hid:any){
  //   this.hotel.id=hid;
  // }     

  updateHotel(){
    var  myhotel:Update= new Update();
    myhotel.id = this.hotel.id;
    myhotel.hotelName = this.hotel.hotelName;
    myhotel.facility = this.hotel.facility;
    // this.className= "spinner-border";
     this.hotelService.updateHotel(myhotel).subscribe(data=>{
       this.hotel = data as Hotel;
       if(this.hotel.id>0){
         alert("The Hotel has been updated");
         this.router.navigateByUrl("hotels");
       }
       else{
         alert("Sorry , unable to update at this Moment")
       }
     },
     (err)=>{
       console.log(err);
     })
        // alert("check after the async")
     this.hotel =new Hotel();
   }
   cancel(){
    this.router.navigateByUrl("home");
  }
  }
  
