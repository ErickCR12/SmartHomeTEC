import { Component, OnInit } from '@angular/core';
import {DataService} from '../../data.service';
import {UsersService} from '../../users.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {

  isMonthlyUsage = false;
  isDailyUsage = false;
  isDeviceTypeUsage = false;
  monthlyUsage = 0;

  constructor(private dataService: DataService, private usersService: UsersService) {
  }

  ngOnInit(): void {
    this.getMonthlyUsage();
  }

  clickMonthlyUsage(): void{
    this.isMonthlyUsage = true;
    this.isDailyUsage = false;
    this.isDeviceTypeUsage = false;
  }

  clickDailyUsage(): void{
    this.isMonthlyUsage = false;
    this.isDailyUsage = true;
    this.isDeviceTypeUsage = false;
  }

  clickDeviceTypesUsage(): void{
    this.isMonthlyUsage = false;
    this.isDailyUsage = false;
    this.isDeviceTypeUsage = true;
  }

  getMonthlyUsage(): void{
    this.dataService.getMonthlyUsage(this.usersService.client.email)
      .subscribe(data => this.monthlyUsage = data.numerical_value);
  }

}
