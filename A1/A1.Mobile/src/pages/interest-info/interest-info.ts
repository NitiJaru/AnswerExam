import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { ServiceProvider } from '../../providers/service/service';

/**
 * Generated class for the InterestInfoPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-interest-info',
  templateUrl: 'interest-info.html',
})
export class InterestInfoPage {

  PrincipleAmount: number;
  YearAmount: number;
  constructor(public navCtrl: NavController, public navParams: NavParams, private svc: ServiceProvider) {
  }

  Next() {
    this.svc.PrincipleAmount = this.PrincipleAmount;
    this.svc.YearAmount = this.YearAmount;
    this.navCtrl.push('ResultPage');
  }

}
