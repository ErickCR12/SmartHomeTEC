import { Component, OnInit } from '@angular/core';
import {DeviceType} from '../../models/device-type';
import {DataService} from '../../data.service';
import {Device} from '../../models/device';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.css']
})
export class DevicesComponent implements OnInit {

  devices: Device[];
  deviceTypes: DeviceType[];

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getAllDevices();
    this.getAllDeviceTypes();
  }

  getAllDevices(): void{
    this.dataService.getAllDevices().subscribe( data => this.devices = data);
  }

  getAllDeviceTypes(): void{
    this.dataService.getAllDeviceTypes().subscribe( data => this.deviceTypes = data);
  }

  addDevice(serialNumberStr: string, brand: string, electricUsageStr: string, priceStr: string, device_type_name: string): void{
    console.log(device_type_name);
    const serial_number = Number(serialNumberStr);
    const electric_usage = Number(electricUsageStr);
    const price = Number(priceStr);
    const new_device = {serial_number, brand, electric_usage, price, device_type_name} as Device;
    this.dataService.addDevice(new_device).subscribe(data => {
      if (data){
        this.devices.push(new_device);
      }
    });
  }

  deleteDevice(serialNumberStr: string, index: number): void{
    const serial_number = Number(serialNumberStr);
    this.devices.splice(index, 1);
    this.dataService.deleteDevice(serial_number).subscribe();
  }

  updateDevice(serialNumberStr: string, brand: string, electricUsageStr: string, priceStr: string, device_type_name: string): void{
    const serial_number = Number(serialNumberStr);
    const electric_usage = Number(electricUsageStr);
    const price = Number(priceStr);
    const updated_device = {serial_number, brand, electric_usage, price, device_type_name} as Device;
    this.dataService.updateDevice(updated_device).subscribe();
  }


}
