import {Component, Input} from '@angular/core';
import {UsersService} from './users.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'WebApp';

  //________/No Users\______
  isAdmin: boolean = false;
  isLogged: boolean = false;
  notReg: boolean = false;

  constructor() { }

  //________/Client\_______
  notEditProf: boolean = false;
  notShop: boolean = false;
  notReport: boolean = false;

  //________/Admin \_______
  notDeviceType: boolean = false;
  notDevices: boolean = false;
  ActiveDevices: boolean = false;
  UsageDevices: boolean = false;
  UploadDoc: boolean = false;



  changeAdmin(val: boolean){
    this.isAdmin = val;
  }

  changeLogged(val: boolean){
    this.isLogged = val;
  }

  //____________________/Client Tabs\_____________________
  clickProfEdit() {
    this.notEditProf = !this.notEditProf;
    this.notShop = false;
    this.notReport = false;
  }

  clickShop() {
    this.notShop = !this.notShop;
    this.notEditProf = false;
    this.notReport = false;
  }

  clickReports() {
    this.notReport = !this.notReport;
    this.notEditProf = false;
    this.notShop = false;
  }

  //___________________/No User Tabs\______________________
  clickLog() {
    this.isLogged = false;
    this.clickSeeDevs();
    this.clickShop();
    this.notShop = false;
    this.ActiveDevices = false;
  }

  clickADMN() {
    this.isAdmin = !this.isAdmin;
  }

  clickReg() {
    this.notReg = !this.notReg;
    this.isLogged = !this.isLogged;
  }

  //____________________/Admin Tabs\______________________
  clickSeeDevs() {
    this.ActiveDevices = !this.ActiveDevices
    this.UsageDevices = false;
    this.notDevices = false;
    this.notDeviceType = false;
    this.UploadDoc = false
  }

  clickUsageDevices() {
    this.UsageDevices = !this.UsageDevices;
    this.ActiveDevices = false;
    this.notDevices = false;
    this.notDeviceType = false;
    this.UploadDoc = false
  }

  clickUploadDoc() {
    this.UploadDoc = !this.UploadDoc
    this.UsageDevices = false;
    this.ActiveDevices = false;
    this.notDevices = false;
    this.notDeviceType = false
  }

  //type devices
  clickDeviceManager() {
    this.notDeviceType = !this.notDeviceType;
    this.UsageDevices = false;
    this.ActiveDevices = false;
    this.notDevices = false;
    this.UploadDoc = false
  }

  clickDevices() {
    this.notDevices = !this.notDevices;
    this.UsageDevices = false;
    this.ActiveDevices = false;
    this.notDeviceType = false;
    this.UploadDoc = false
  }

}
