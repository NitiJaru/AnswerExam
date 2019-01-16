import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

@IonicPage()
@Component({
  selector: 'page-order-product',
  templateUrl: 'order-product.html',
})
export class OrderProductPage {

  model: any = {};
  constructor(public navCtrl: NavController, public navParams: NavParams, private http: HttpClient) {
    var data = this.navParams.data;
    this.model.name = data.name;
    this.model.pricePerUnit = data.price;
  }

  AddToCart() {
    let option = { "headers": { "Content-Type": "application/json" } };
    this.http.post("https://localhost:5001/api/POS/OrderProduct", this.model, option).subscribe(it => {
      this.navCtrl.pop();
      this.navCtrl.push('CartInfoPage');
    });
  }
}
