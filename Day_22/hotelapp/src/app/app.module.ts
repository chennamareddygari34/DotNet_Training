import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HotelComponent } from './hotel/hotel.component';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HotelService } from './services/hotel.service';
import { HotelsComponent } from './hotels/hotels.component';
import { LoginComponent } from './login/login.component';
import { UserService } from './services/user.service';
import { HomeComponent } from './home/home.component';
import { DeleteComponent } from './delete/delete.component';
import { UpdateComponent } from './update/update.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from './services/auth.service';
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
    UpdateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config:{
        tokenGetter:tokenGetter,
        allowedDomains:["http://localhost:5268/"]
      }
  })
  ],
  providers: [HotelService,UserService,AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
