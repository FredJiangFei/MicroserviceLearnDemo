import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Order } from '../_models/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  constructor(private http: HttpClient) {}

  postOrder(orderRequest: any) {
    return this.http.post(`${environment.baseUrl}/orders`, orderRequest);
  }

  getOrders() {
    return this.http.get<Order[]>(`${environment.baseUrl}/orders`);
  }

  getOrder(id: number) {
    return this.http.get<Order>(`${environment.baseUrl}/orders/${id}`);
  }
}
