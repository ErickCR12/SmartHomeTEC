import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'WebApp';
  notLogged: boolean = false;
  notReg: boolean = false;
  notEditProf: boolean = false;
  notShop: boolean = false;
  notReport: boolean = false;

  clickLog() {
    this.notLogged = !this.notLogged
  }
  clickReg() {
    this.notReg = !this.notReg
  }

  clickProfEdit() {
    this.notEditProf = !this.notEditProf
  }

  clickShop() {
    this.notShop = !this.notShop
  }

  clickReports() {
    this.notReport = !this.notReport
  }
}
