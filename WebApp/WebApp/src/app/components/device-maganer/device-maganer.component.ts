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

  addDeviceType(name: string, description: string, warranty_months_str: string): void{
    let warranty_months = Number(warranty_months_str);
    let new_device_type = {name, description, warranty_months} as DeviceType;
    this.dataService.addDeviceType(new_device_type).subscribe(data => {
      if (data){
        this.deviceTypes.push(new_device_type);
      }
    });
  }

  deleteDeviceType(name: string, index: number): void{
    this.deviceTypes.splice(index, 1);
    this.dataService.deleteDeviceType(name).subscribe();
  }

  updateDeviceType(name: string, description: string, warranty_months_str: string): void{
    let warranty_months = Number(warranty_months_str);
    let updated_device_type = {name, description, warranty_months} as DeviceType;
    this.dataService.updateDeviceType(updated_device_type).subscribe();
  }

}
