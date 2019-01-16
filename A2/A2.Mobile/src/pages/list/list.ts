import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'page-list',
  templateUrl: 'list.html'
})
export class ListPage {

  model: any = [];
  constructor(public navCtrl: NavController, public navParams: NavParams, private http: HttpClient) {
  }

  AddProduct() { this.navCtrl.push('CreateProductPage'); }

  ionViewDidEnter() {
    this.http.get("https://localhost:5001/api/POS/GetProducts").subscribe(it => {
      this.model = it;
    });
  }
}
