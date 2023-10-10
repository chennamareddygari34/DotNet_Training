import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { ProductsComponent } from './products/products.component';
import { RegistrationComponent } from './registration/registration.component';
import { FormsModule } from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';
import{ HttpClientModule}from '@angular/common/http'
import { AuthGuard } from './services/authservice';
import { Productservice } from './services/productservice';
import { UserService } from './services/userservice';
import { CartComponent } from './cart/cart.component';
import { CartitemdetailComponent } from './cartitemdetail/cartitemdetail.component';
import { AddproductComponent } from './addproduct/addproduct.component';
import { OrderconfirmationComponent } from './orderconfirmation/orderconfirmation.component';
import { FilterPipe } from './products/filter.pipe';
export function tokenGetter(){
  return sessionStorage.getItem("token");
}

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    ProductsComponent,
    RegistrationComponent,
    CartComponent,
    CartitemdetailComponent,
    AddproductComponent,
    OrderconfirmationComponent,
    FilterPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config:{
        tokenGetter:tokenGetter,
        allowedDomains:["http://localhost:5158/"]
      }
  })
  ],
  providers: [AuthGuard,Productservice,UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
