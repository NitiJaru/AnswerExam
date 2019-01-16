import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { ServiceProvider } from '../../providers/service/service';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  rate: any;
  constructor(public navCtrl: NavController, private svc: ServiceProvider) {

  }

  Next() {
    this.svc.InterestRate = this.rate
    this.navCtrl.push('InterestInfoPage');
  }

}
