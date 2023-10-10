import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HotelComponent } from './hotel/hotel.component';
import { HotelsComponent } from './hotels/hotels.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { DeleteComponent } from './delete/delete.component';
import { UpdateComponent } from './update/update.component';
import { AuthGuard } from './services/auth.service';
import { RoomComponent } from './room/room.component';
import { UpdateroomComponent } from './updateroom/updateroom.component';
import { RoomsComponent } from './rooms/rooms.component';
import { DeleteroomComponent } from './deleteroom/deleteroom.component';

const routes: Routes = [
  {path:'home',component:HomeComponent,canActivate:[AuthGuard]},
  {path:'hotels',component:HotelsComponent},
  {path:'add',component:HotelComponent,canActivate:[AuthGuard]},
  {path:'login',component:LoginComponent},
  {path:'delete',component:DeleteComponent},
  {path:'update',component:UpdateComponent},
  {path:'addroom',component:RoomComponent},
  {path:'updateroom',component:UpdateroomComponent},
  {path:'deleteroom',component:DeleteroomComponent},
  {path:'rooms',component:RoomsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
