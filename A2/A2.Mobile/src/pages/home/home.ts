import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  model: any = [];
  constructor(public navCtrl: NavController, private http: HttpClient) {

  }

  ionViewDidEnter() {
    this.http.get("https://localhost:5001/api/POS/GetProducts").subscribe(it => {
      this.model = it;
    });
  }

  Purchase(item) { this.navCtrl.push('OrderProductPage', item); }
  GoToCart() { this.navCtrl.push('CartInfoPage'); }
}
