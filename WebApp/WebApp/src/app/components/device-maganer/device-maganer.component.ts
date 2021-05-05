import { Component, OnInit } from '@angular/core';
import {DataService} from '../../data.service';
import {DeviceType} from '../../models/device-type';

@Component({
  selector: 'app-device-maganer',
  templateUrl: './device-maganer.component.html',
  styleUrls: ['./device-maganer.component.css']
})
export class DeviceMaganerComponent implements OnInit {

  deviceTypes: DeviceType[];


  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getAllDeviceTypes();
  }

  getAllDeviceTypes(): void{
    this.dataService.getAllDeviceTypes().subscribe( data => this.deviceTypes = data);
  }

}
