import { Component, OnInit } from '@angular/core';
import {DevicesPerUser} from '../../models/devices-per-user';
import {DataService} from '../../data.service';

@Component({
  selector: 'app-devices-per-user',
  templateUrl: './devices-per-user.component.html',
  styleUrls: ['./devices-per-user.component.css']
})
export class DevicesPerUserComponent implements OnInit {

  devicesPerUser: DevicesPerUser;
  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getDevicesPerUser();
  }

  getDevicesPerUser(): void{
    this.dataService.getDevicesPerUser().subscribe(data => this.devicesPerUser = data);
  }

}
