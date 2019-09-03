import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderComponent } from './order.component';
import { OrderRoutingModule } from './order-routing.module';
import { ShareModule } from '../_shared/share.module';

@NgModule({
  declarations: [OrderComponent],
  imports: [CommonModule, ShareModule, OrderRoutingModule]
})
export class OrderModule {}
