import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { InterestInfoPage } from './interest-info';

@NgModule({
  declarations: [
    InterestInfoPage,
  ],
  imports: [
    IonicPageModule.forChild(InterestInfoPage),
  ],
})
export class InterestInfoPageModule {}
