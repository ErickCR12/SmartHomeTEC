import { Component, OnInit } from '@angular/core';
import {Region} from '../../models/region';
import {DataService} from '../../data.service';
import {Distributor} from '../../models/distributor';
import {Device} from '../../models/device';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  distributors: Distributor[];

  constructor(private dataService: DataService) {
  }

  ngOnInit(): void {
  }

  getOnlineStore(country: string, continent: string): void {
    this.dataService.getOnlineStore({country, continent} as Region).subscribe(data => this.distributors = data);
  }
}
