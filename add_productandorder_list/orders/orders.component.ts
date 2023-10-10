import { Component } from '@angular/core';
import { OrderService } from '../services/order.service';
import { Order } from '../order/order';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent {
  orders:Order[]=[];
  order:Order = new Order();
  
  constructor(private orderService:OrderService){
    this.orderService.getOrders().subscribe(data=>{
      console.log(data)
      this.orders = data as Order[];
    })
  }}


