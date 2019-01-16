import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { ServiceProvider } from '../../providers/service/service';
import { HttpClient } from '@angular/common/http';

@IonicPage()
@Component({
  selector: 'page-result',
  templateUrl: 'result.html',
})
export class ResultPage {

  model;
  constructor(public navCtrl: NavController, public navParams: NavParams, private svc: ServiceProvider, private http: HttpClient) {
    let option = { "headers": { "Content-Type": "application/json" } };
    this.http.post("https://localhost:5001/api/Interest?interestPercent=" + this.svc.InterestRate, null, option).subscribe();
    this.http.get("https://localhost:5001/api/Interest/" + this.svc.PrincipleAmount + "/" + this.svc.YearAmount).subscribe(it => {
      this.model = it;
    });
  }

  home() {
    this.navCtrl.popToRoot();
  }

}
