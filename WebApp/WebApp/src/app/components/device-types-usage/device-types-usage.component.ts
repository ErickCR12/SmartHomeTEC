import { Component, OnInit } from '@angular/core';
import {DataService} from '../../data.service';
import {UsersService} from '../../users.service';
import {Report} from '../../models/report';

@Component({
  selector: 'app-device-types-usage',
  templateUrl: './device-types-usage.component.html',
  styleUrls: ['./device-types-usage.component.css']
})
export class DeviceTypesUsageComponent implements OnInit {

  reports: Report[];

  constructor(private dataService: DataService, private usersService: UsersService) {
    this.getDeviceTypesUsage();
  }

  ngOnInit(): void {
  }

  getDeviceTypesUsage(): void{
    this.dataService.getDeviceTypesUsage(this.usersService.client.email).subscribe(data => this.reports = data);
  }
}
