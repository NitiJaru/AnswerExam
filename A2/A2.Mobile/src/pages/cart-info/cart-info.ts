import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

@IonicPage()
@Component({
  selector: 'page-cart-info',
  templateUrl: 'cart-info.html',
})
export class CartInfoPage {

  model: any = {};
  constructor(public navCtrl: NavController, public navParams: NavParams, private http: HttpClient) {
  }

  ionViewDidLoad() {
    this.http.get("https://localhost:5001/api/POS/GetCart").subscribe(it => {
      this.model = it;
    });
  }

}
