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
  deviceToBuy: Device;
  iToDelete = -1;
  jToDelete = -1;

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

  addDevice(i: number, j: number): void{
    this.deviceToBuy = this.distributors[i].devices[j];
    this.iToDelete = i;
    this.jToDelete = j;
  }

  addOrder(device_serial_number: number, price: number): void{
    const client_email = this.client.email;
    const purchase_date = formatDate(new Date(), 'yyyy/MM/dd', 'en');
    const purchase_time = formatDate(new Date(), 'hh:mm', 'en');
    const newOrder = {price, purchase_time, purchase_date, client_email, device_serial_number} as Order;
    this.distributors[this.iToDelete].devices.splice(this.jToDelete, 1);
    this.dataService.addOrder(newOrder).subscribe();
    this.cancelOrder();
  }

  cancelOrder(): void{
    this.deviceToBuy = null;
    this.iToDelete = -1;
    this.jToDelete = -1;
  }

}
