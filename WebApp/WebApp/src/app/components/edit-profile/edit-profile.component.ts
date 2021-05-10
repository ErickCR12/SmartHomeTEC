import { Component, OnInit } from '@angular/core';
import {Region} from '../../models/region';
import {DataService} from '../../data.service';
import {DirectionClient} from '../../models/direction-client';
import {Client} from '../../models/client';
import {UsersService} from '../../users.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {

  client: Client;
  continents: Region[];
  countries: Region[];

  constructor(private dataService: DataService, private usersService: UsersService) { }

  ngOnInit(): void {
    this.getAllContinents();
    this.client = this.usersService.client;
  }

  getAllContinents(): void{
    this.dataService.getAllContinents().subscribe(data => this.continents = data);
  }

  getAllCountries(continent: string): void{
    this.dataService.getCountriesByContinent(continent).subscribe(data => this.countries = data);
  }

  addDirectionClient(direction: string): void{
    if (!this.client) { return; }
    const client_email = this.client.email;
    this.dataService.addDirectionClient({direction, client_email} as DirectionClient).subscribe();
  }

  updateClient(name: string, last_name1: string, last_name2: string, continent: string,
               country: string, password: string): void{
    const email = this.client.email;
    const updatedClient = {email, name, last_name1, last_name2, continent, country, password} as Client;
    this.usersService.client = updatedClient;
    this.dataService.updateClient(updatedClient).subscribe();
  }
}
