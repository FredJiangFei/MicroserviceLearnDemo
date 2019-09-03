import { Component, OnInit } from "@angular/core";
import { OrderService } from "../_services/order.service";
import { Order } from "../_models/order";

@Component({
  selector: "app-order",
  templateUrl: "./order.component.html",
  styleUrls: ["./order.component.css"]
})
export class OrderComponent implements OnInit {
  orders: Order[];
  order: Order;

  constructor(private orderService: OrderService) {}

  ngOnInit() {
    this.getOrders();
  }

  getOrders() {
    this.orderService.getOrders().subscribe(orders => {
      this.orders = orders;
    });
  }

  getOrder(id: number) {
    this.orderService.getOrder(id).subscribe(order => {
      this.order = order;
    });
  }

  submitOrder() {
    const orderRequest = {
      details: [
        {
          sku: "123",
          name: "iphone6"
        }
      ]
    };
    this.orderService.postOrder(orderRequest).subscribe(() => {});
  }
}
