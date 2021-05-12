import { Component, OnInit } from '@angular/core';
import {Region} from '../../models/region';
import {DataService} from '../../data.service';

@Component({
  selector: 'app-devices-per-region',
  templateUrl: './devices-per-region.component.html',
  styleUrls: ['./devices-per-region.component.css']
})
export class DevicesPerRegionComponent implements OnInit {

  regions: Region[];
  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getDevicesPerRegion();
  }

  getDevicesPerRegion(): void{
    this.dataService.getDevicesPerRegion().subscribe(data => this.regions = data);
  }

}
