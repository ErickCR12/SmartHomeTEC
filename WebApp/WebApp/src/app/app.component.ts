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
  notDeviceType: boolean = false;
  notDevices: boolean = false;
  ActiveDevices: boolean = false;
  UsageDevices: boolean = false;
  UploadDoc: boolean = false;

  clickLog() {
    this.notLogged = !this.notLogged
  }
  clickReg() {
    this.notReg = !this.notReg
  }

  clickSeeDevs() {
    this.ActiveDevices = !this.ActiveDevices
  }

  clickUsageDevices() {
    this.UsageDevices = !this.UsageDevices
  }

  clickUploadDoc() {
    this.UploadDoc = !this.UploadDoc
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
  //type devices
  clickDeviceManager() {
    this.notDeviceType = !this.notDeviceType
  }

  clickDevices() {
    this.notDevices = !this.notDevices
  }
}
