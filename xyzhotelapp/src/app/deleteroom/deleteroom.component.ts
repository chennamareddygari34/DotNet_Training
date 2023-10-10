import { Component } from '@angular/core';
import { Room } from '../room/room';
import { RoomService } from '../services/room.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-deleteroom',
  templateUrl: './deleteroom.component.html',
  styleUrls: ['./deleteroom.component.css']
})
export class DeleteroomComponent {
  room:Room= new Room();
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

  deleteRoom(){
    this.roomService.deleteRoom(this.room.roomId).subscribe(htl=>{
      if(htl){
        alert("Room deleted...");
        this.router.navigateByUrl("rooms");
      }
    })
    this.room = new Room();
  }
  cancel(){
    this.router.navigateByUrl("rooms");
  } 

  back(){
    this.router.navigateByUrl("rooms");
  }
}
