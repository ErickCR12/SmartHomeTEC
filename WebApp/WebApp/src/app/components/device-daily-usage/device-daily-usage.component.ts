import { Component, OnInit } from '@angular/core';
import {Report} from '../../models/report';
import {DataService} from '../../data.service';
import {UsersService} from '../../users.service';

@Component({
  selector: 'app-device-daily-usage',
  templateUrl: './device-daily-usage.component.html',
  styleUrls: ['./device-daily-usage.component.css']
})
export class DeviceDailyUsageComponent implements OnInit {

  reports: Report[];

  constructor(private dataService: DataService, private usersService: UsersService) {
    this.getDailyUsage();
  }

  ngOnInit(): void {
  }

  getDailyUsage(): void{
    this.dataService.getDailyUsage(this.usersService.client.email).subscribe(data => this.reports = data);
  }

}
