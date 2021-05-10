import { Component } from '@angular/core';
import {DataService} from '../../data.service';
import {Login} from '../../models/login';
import {UsersService} from '../../users.service';
import {Client} from '../../models/client';
import {Admin} from '../../models/admin';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'loginScreen',
  templateUrl: './login.component.html' ,
  styleUrls: ['./login.component.css']
})
// tslint:disable-next-line:component-class-suffix
export class LoginScreen {

  constructor(private dataService: DataService, private usersService: UsersService) { }

  checkCredentials(username: string, password: string): void{
    this.dataService.getLoginCredentials({username, password} as Login).subscribe(
      data =>
      {
        if (data.userType === 'Client'){
          this.getClientByEmail(username);
          this.usersService.isAdmin = false;
        }
        else if (data.userType === 'Admin'){
          this.usersService.admin = {username, password} as Admin;
          this.usersService.isAdmin = true;
        }
      });
  }

  getClientByEmail(email: string): void{
    this.dataService.getClientByEmail(email).subscribe(data => this.usersService.client = data);
  }


}
