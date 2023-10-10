import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RoomService } from '../services/room.service';
import { Room } from './room';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css']
})
export class RoomComponent {
  room:Room = new Room();
  className:string="";
  constructor(private roomService:RoomService,private router:Router){
  }

  addRoom(){
    this.className= "spinner-border";
    this.roomService.addRoom(this.room).subscribe(data=>{
      this.room = data as Room;
      if(this.room.roomId>0)
      {
        alert("The room has been added");
        this.router.navigateByUrl("rooms");
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
    this.room = new Room();
  }
  changeId(rid:any){
    this.room.roomId=rid;
  }     

  back(){
    this.router.navigateByUrl("rooms");
  }
}
