import { Component, Input } from '@angular/core';
import { Productservice } from '../services/productservice';
import { OrderResponseDto } from '../models/orderresponsedto';

@Component({
  selector: 'app-orderconfirmation',
  templateUrl: './orderconfirmation.component.html',
  styleUrls: ['./orderconfirmation.component.css']
})
export class OrderconfirmationComponent {

  @Input()ordersdetail:OrderResponseDto = new OrderResponseDto();

  constructor(private productservice:Productservice){
   
   
  }

}
