import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductComponent } from './product/product.component';
import { ProductsComponent } from './products/products.component';
import { ProductService } from './services/product.service';
import { FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { ProductWebService } from './services/productweb.service';

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    ProductsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [ProductService, ProductWebService],
  bootstrap: [AppComponent]
})
export class AppModule { }
