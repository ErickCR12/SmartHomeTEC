import { Component, OnInit } from '@angular/core';
import {DeviceType} from '../../models/device-type';
import {DataService} from '../../data.service';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.css']
})
export class DevicesComponent implements OnInit {

  deviceTypes: DeviceType[];

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getAllDeviceTypes();
    console.log(this.deviceTypes);
  }

  getAllDeviceTypes(): void{
    this.dataService.getAllDeviceTypes().subscribe( data => console.log(data));
  }

}
