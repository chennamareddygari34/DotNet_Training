import { Component } from '@angular/core';
import { Room } from '../room/room';
import { RoomService } from '../services/room.service';
import { Router } from '@angular/router';
import { UpdateRoom } from './updateroom';

@Component({
  selector: 'app-updateroom',
  templateUrl: './updateroom.component.html',
  styleUrls: ['./updateroom.component.css']
})
export class UpdateroomComponent {
  room:Room= new Room();
  className:string="";
  rooms:Room[]=[];
  constructor(private roomService:RoomService,private router:Router){
    this.roomService.getRooms().subscribe(htl=>{
      this.rooms = htl as Room[];
    })
  }

  selectChange(htl:any){
    for (let index = 0; index < this.rooms.length; index++) {
      if(this.rooms[index].roomId==htl)
      {
        this.room = this.rooms[index];
        break;
      }
    }
  } 

  updateRoom(){
    var  myroom:UpdateRoom= new UpdateRoom();
    myroom.roomId = this.room.roomId;
    myroom.price = this.room.price;
    // this.className= "spinner-border";
     this.roomService.updateRoom(myroom).subscribe(data=>{
       this.room = data as Room;
       if(this.room.roomId>0){
         alert("The Room has been updated");
         this.router.navigateByUrl("rooms");
       }
       else{
         alert("Sorry , unable to update at this Moment")
       }
     },
     (err)=>{
       console.log(err);
     })
        // alert("check after the async")
     this.room =new Room();
   }
   back(){
    this.router.navigateByUrl("rooms");
  }
}
