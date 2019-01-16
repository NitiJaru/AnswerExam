import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { OrderProductPage } from './order-product';

@NgModule({
  declarations: [
    OrderProductPage,
  ],
  imports: [
    IonicPageModule.forChild(OrderProductPage),
  ],
})
export class OrderProductPageModule {}
