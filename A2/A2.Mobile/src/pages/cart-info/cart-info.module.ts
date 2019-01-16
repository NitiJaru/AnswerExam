import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { CartInfoPage } from './cart-info';

@NgModule({
  declarations: [
    CartInfoPage,
  ],
  imports: [
    IonicPageModule.forChild(CartInfoPage),
  ],
})
export class CartInfoPageModule {}
