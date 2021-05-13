import { Component, OnInit } from '@angular/core';
import {Region} from '../../models/region';
import {DataService} from '../../data.service';
import {Distributor} from '../../models/distributor';
import {Device} from '../../models/device';
import {UsersService} from '../../users.service';
import {Client} from '../../models/client';
import {formatDate} from '@angular/common';
import { Order } from '../../models/order';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css'],
  providers: [NgbModalConfig, NgbModal]
})
export class ShopComponent implements OnInit {

  distributors: Distributor[];
  client: Client;

  constructor(private dataService: DataService, private usersService: UsersService, config: NgbModalConfig, private modalService: NgbModal) {
    config.backdrop = 'static';
    config.keyboard = false;
  }

  open(content) {
    this.modalService.open(content);
  }

  ngOnInit(): void {
    this.client = this.usersService.client;
    this.getOnlineStore(this.client.country, this.client.continent);
  }

  getOnlineStore(country: string, continent: string): void {
    this.dataService.getOnlineStore({country, continent} as Region).subscribe(data => this.distributors = data);
  }

  addOrder(serialNumberStr: string, priceStr: string, i: number, j: number): void{
    const device_serial_number = Number(serialNumberStr);
    const price = Number(priceStr);
    const client_email = this.client.email;
    const purchase_date = formatDate(new Date(), 'yyyy/MM/dd', 'en');
    const purchase_time = formatDate(new Date(), 'hh:mm', 'en');
    const newOrder = {price, purchase_time, purchase_date, client_email, device_serial_number} as Order;
    console.log(newOrder);
    this.distributors[i].devices.splice(j, 1);
    this.dataService.addOrder(newOrder).subscribe();
  }

}
