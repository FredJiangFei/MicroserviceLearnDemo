import { Component, OnInit } from '@angular/core';
import { OrderService } from '../_services/order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
  constructor(private orderService: OrderService) {}

  ngOnInit() {}

  submitOrder() {
    const orderRequest = {
      details: [
        {
          sku: '123',
          name: 'iphone6'
        }
      ]
    };
    this.orderService.postOrder(orderRequest).subscribe(() => {});
  }
}
