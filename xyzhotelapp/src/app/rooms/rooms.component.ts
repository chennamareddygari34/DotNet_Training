import { Component } from '@angular/core';
import { RoomService } from '../services/room.service';
import { Room } from '../room/room';
import { Router } from '@angular/router';

@Component({
  selector: 'app-rooms',
  templateUrl: './rooms.component.html',
  styleUrls: ['./rooms.component.css']
})
export class RoomsComponent {
  rooms:Room[]=[];
  constructor(private roomService:RoomService, private router:Router){
    this.roomService.getRooms().subscribe(data=>{
      console.log(data)
      this.rooms = data as Room[];     
     })
  }
  addRoom(){
    this.router.navigateByUrl("addroom");
  }
  updateRoom(){
    this.router.navigateByUrl("updateroom");
  }
  deleteRoom(){
    this.router.navigateByUrl("deleteroom");
  }
  back(){
    this.router.navigateByUrl("hotels");
  }
}
