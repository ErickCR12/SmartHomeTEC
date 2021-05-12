import { Component, OnInit } from '@angular/core';
import {Device} from '../../models/device';
import {DataService} from '../../data.service';

@Component({
  selector: 'app-device-list-table',
  templateUrl: './device-list-table.component.html',
  styleUrls: ['./device-list-table.component.css']
})
export class DeviceListTableComponent implements OnInit {

  devices: Device[];
  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getAllDevices();
  }

  getAllDevices(): void{
    this.dataService.getAllDevices().subscribe(data => this.devices = data);
  }
}
