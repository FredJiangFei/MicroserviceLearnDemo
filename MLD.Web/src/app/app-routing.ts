import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      { path: 'orders', loadChildren: './order/order.module#OrderModule' },
      {
        path: 'products',
        loadChildren: './product/product.module#ProductModule'
      }
    ]
  }
];
