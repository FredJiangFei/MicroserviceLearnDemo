import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }

  postOrder(orderRequest: any) {
    return this.http.post(`${environment.baseUrl}/orders`, orderRequest);
  }
}
