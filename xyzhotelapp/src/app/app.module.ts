import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HotelComponent } from './hotel/hotel.component';
import { FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { HotelService } from './services/hotel.service';
import { HotelsComponent } from './hotels/hotels.component';
import { LoginComponent } from './login/login.component';
import { UserService } from './services/user.service';
import { HomeComponent } from './home/home.component';
import { DeleteComponent } from './delete/delete.component';
import { UpdateComponent } from './update/update.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from './services/auth.service';
import { RoomComponent } from './room/room.component';
import { RoomsComponent } from './rooms/rooms.component';
import { UpdateroomComponent } from './updateroom/updateroom.component';
import { DeleteroomComponent } from './deleteroom/deleteroom.component';
import { RoomService } from './services/room.service';
import { BookingComponent } from './booking/booking.component';
import { BookingsComponent } from './bookings/bookings.component';
import { DeletebookingComponent } from './deletebooking/deletebooking.component';
import { UpdatebookingComponent } from './updatebooking/updatebooking.component';

export function tokenGetter(){
  return sessionStorage.getItem("token");
}

@NgModule({
  declarations: [
    AppComponent,
    HotelComponent,
    HotelsComponent,
    LoginComponent,
    HomeComponent,
    DeleteComponent,
    UpdateComponent,
    RoomComponent,
    RoomsComponent,
    UpdateroomComponent,
    DeleteroomComponent,
    BookingComponent,
    BookingsComponent,
    DeletebookingComponent,
    UpdatebookingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config:{
        tokenGetter:tokenGetter,
        allowedDomains:["http://localhost:5156/"]
      }
  })
  ],
  providers: [HotelService,UserService, AuthGuard, RoomService],
  bootstrap: [AppComponent]
})
export class AppModule { }
