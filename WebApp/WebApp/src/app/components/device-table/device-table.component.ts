import { Component, OnInit } from '@angular/core';
import {DevicesPerUser} from '../../models/devices-per-user';
import {DataService} from '../../data.service';

@Component({
  selector: 'app-device-table',
  templateUrl: './device-table.component.html',
  styleUrls: ['./device-table.component.css']
})
export class DeviceTableComponent implements OnInit {

  devicesPerUser: DevicesPerUser;
  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getDevicesPerUser();
  }

  getDevicesPerUser(): void{
    this.dataService.getDevicesPerUser().subscribe(data => this.devicesPerUser = data);
  }

}
