import { Component, OnInit } from '@angular/core';
import {DeviceType} from '../../models/device-type';
import {DataService} from '../../data.service';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.css']
})
export class DevicesComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
