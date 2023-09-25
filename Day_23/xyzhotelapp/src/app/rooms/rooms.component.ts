import { Component } from '@angular/core';
import { RoomService } from '../services/room.service';
import { Room } from '../room/room';

@Component({
  selector: 'app-rooms',
  templateUrl: './rooms.component.html',
  styleUrls: ['./rooms.component.css']
})
export class RoomsComponent {
  rooms:Room[]=[];
  constructor(private roomService:RoomService){
    this.roomService.getRooms().subscribe(data=>{
      console.log(data)
      this.rooms = data as Room[];     
     })
  }
}
