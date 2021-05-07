import { Component, OnInit } from '@angular/core';
import {DataService} from '../../data.service';
import {Client} from '../../models/client';
import {DirectionClient} from '../../models/direction-client';

@Component({
  selector: 'app-register-component',
  templateUrl: './register-component.component.html',
  styleUrls: ['./register-component.component.css']
})
export class RegisterComponent implements OnInit {

  registeredClient: Client;

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
  }

  addClient(email: string, name: string, password: string, last_name1: string, last_name2: string, country: string,
            continent: string, direction: string): void{
    this.registeredClient = {email, name, password, last_name1, last_name2, country, continent, direction} as Client;
    this.dataService.addClient(this.registeredClient)
      .subscribe();
  }

  addDirectionClient(direction: string): void{
    if (!this.registeredClient) { return; }
    const client_email = this.registeredClient.email;
    this.dataService.addDirectionClient({direction, client_email} as DirectionClient).subscribe();
  }

}
