import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { CartComponent } from './cart/cart.component';
import { CartitemdetailComponent } from './cartitemdetail/cartitemdetail.component';
import { HeaderComponent } from './header/header.component';
import { ProductsComponent } from './products/products.component';
import { AddproductComponent } from './addproduct/addproduct.component';
import { OrderconfirmationComponent } from './orderconfirmation/orderconfirmation.component';
import { AuthGuard } from './services/authservice';

const routes: Routes = [

  {path:'login',component:LoginComponent},

  {path:'reg',component:RegistrationComponent},
  {path:'cart',component:CartComponent,canActivate:[AuthGuard]},
  {path:'cartdetail/:cId',component:CartitemdetailComponent},
  {path:'header/:count',component:HeaderComponent},
  {path:'',component:ProductsComponent},
  {path:'addproduct',component:AddproductComponent},
  {path:'orderConfirmation',component:OrderconfirmationComponent},

  
  

  


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
