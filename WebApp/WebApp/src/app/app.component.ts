import { Component } from '@angular/core';
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
  notLogged: boolean = false;
  notReg: boolean = false;

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

  constructor(private usersService: UsersService) {
  }

  //____________________/Client Tabs\_____________________
  clickProfEdit() {
    this.notEditProf = !this.notEditProf;
    this.notShop = false;
    this.notReport = false
  }

  clickShop() {
    this.notShop = !this.notShop;
    this.notEditProf = false;
    this.notReport = false
  }

  clickReports() {
    this.notReport = !this.notReport;
    this.notEditProf = false;
    this.notShop = false
  }

  //___________________/No User Tabs\______________________
  clickLog() {
    this.notLogged = !this.notLogged
  }

  clickADMN() {
    this.isAdmin = !this.isAdmin
  }

  clickReg() {
    this.notReg = !this.notReg
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
