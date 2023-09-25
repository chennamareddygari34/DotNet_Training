import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HotelComponent } from './hotel/hotel.component';
import { HotelsComponent } from './hotels/hotels.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { DeleteComponent } from './delete/delete.component';
import { UpdateComponent } from './update/update.component';
import { AuthGuard } from './services/auth.service';

const routes: Routes = [

  {path:'home',component:HomeComponent},

  {path:'hotels',component:HotelsComponent},

  {path:'add',component:HotelComponent,canActivate:[AuthGuard]},

  {path:'delete',component:DeleteComponent},
  {path:'update',component:UpdateComponent},
  //children:[
       // {path:'first',component:FirstComponent }

  //]},

  {path:'login',component:LoginComponent}
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
