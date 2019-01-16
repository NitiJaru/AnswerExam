import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

@IonicPage()
@Component({
  selector: 'page-create-product',
  templateUrl: 'create-product.html',
})
export class CreateProductPage {

  model: any = {};
  constructor(public navCtrl: NavController, public navParams: NavParams, private http: HttpClient) {
  }

  CreateProduct() {
    let option = { "headers": { "Content-Type": "application/json" } };
    this.http.post("https://localhost:5001/api/POS/CreateProduct", this.model, option).subscribe(it => {
      this.navCtrl.pop();
    });
  }

}
