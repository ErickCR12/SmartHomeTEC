import { Component, OnInit } from '@angular/core';
import {DataService} from '../../data.service';

@Component({
  selector: 'app-dasboard',
  templateUrl: './dasboard.component.html',
  styleUrls: ['./dasboard.component.css']
})
export class DasboardComponent implements OnInit {

  isDevicesPerUser = true;
  isAmountDevices = false;
  isDevicesPerRegion = false;
  isDevicesList = false;

  activeDevices: number;

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getActiveDevices();
  }

  getActiveDevices(): void{
    this.dataService.getActiveDevices().subscribe(data => this.activeDevices = data.numerical_value);
  }

  clickDevicesPerUser(): void {
    this.isDevicesPerUser = true;
    this.isAmountDevices = false;
    this.isDevicesPerRegion = false;
    this.isDevicesList = false;
  }
  clickAmountDevices(): void {
    this.isDevicesPerUser = false;
    this.isAmountDevices = true;
    this.isDevicesPerRegion = false;
    this.isDevicesList = false;
  }
  clickDevicesPerRegion(): void {
    this.isDevicesPerUser = false;
    this.isAmountDevices = false;
    this.isDevicesPerRegion = true;
    this.isDevicesList = false;
  }
  clickDevicesList(): void {
    this.isDevicesPerUser = false;
    this.isAmountDevices = false;
    this.isDevicesPerRegion = false;
    this.isDevicesList = true;
  }


}
