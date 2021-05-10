import { Component, OnInit } from '@angular/core';
import {Region} from '../../models/region';
import {DataService} from '../../data.service';
import {Distributor} from '../../models/distributor';
import {Device} from '../../models/device';
import {UsersService} from '../../users.service';
import {Client} from '../../models/client';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  distributors: Distributor[];
  client: Client;

  constructor(private dataService: DataService, private usersService: UsersService) {
  }

  ngOnInit(): void {
    this.client = this.usersService.client;
    this.getOnlineStore(this.client.country, this.client.continent);
  }

  getOnlineStore(country: string, continent: string): void {
    this.dataService.getOnlineStore({country, continent} as Region).subscribe(data => this.distributors = data);
  }
}
