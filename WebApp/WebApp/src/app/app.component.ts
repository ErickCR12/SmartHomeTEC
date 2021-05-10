import {Component, Input} from '@angular/core';
import {UsersService} from './users.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'WebApp';

  // ________/No Users\______
  isReg = false;

  constructor(public usersService: UsersService) { }

  // ________/Client\_______
  isEditProf = false;
  isShop = false;
  isReport = false;

  // ________/Admin \_______
  isDeviceType = false;
  isDevices  = false;
  isActiveDevices  = false;
  isUsageDevices = false;
  isUploadDoc = false;

  // ____________________/Client Tabs\_____________________
  clickProfEdit() {
    this.isEditProf = !this.isEditProf;
    this.isShop = false;
    this.isReport = false;
  }

  clickShop() {
    this.isShop = !this.isShop;
    this.isEditProf = false;
    this.isReport = false;
  }

  clickReports() {
    this.isReport = !this.isReport;
    this.isEditProf = false;
    this.isShop = false;
  }

  // ___________________/No User Tabs\______________________
  clickBack() {
    this.usersService.isLogged = false;
    this.isReg = false;
  }

  clickReg() {
    this.isReg = !this.isReg;
  }

  // ____________________/Admin Tabs\______________________
  clickSeeDevs() {
    this.isActiveDevices = !this.isActiveDevices;
    this.isUsageDevices = false;
    this.isDevices = false;
    this.isDeviceType = false;
    this.isUploadDoc = false;
  }

  clickUsageDevices() {
    this.isUsageDevices = !this.isUsageDevices;
    this.isActiveDevices = false;
    this.isDevices = false;
    this.isDeviceType = false;
    this.isUploadDoc = false;
  }

  clickUploadDoc() {
    this.isUploadDoc = !this.isUploadDoc;
    this.isUsageDevices = false;
    this.isActiveDevices = false;
    this.isDevices = false;
    this.isDeviceType = false;
  }

  // type devices
  clickDeviceManager() {
    this.isDeviceType = !this.isDeviceType;
    this.isUsageDevices = false;
    this.isActiveDevices = false;
    this.isDevices = false;
    this.isUploadDoc = false;
  }

  clickDevices() {
    this.isDevices = !this.isDevices;
    this.isUsageDevices = false;
    this.isActiveDevices = false;
    this.isDeviceType = false;
    this.isUploadDoc = false;
  }

}
