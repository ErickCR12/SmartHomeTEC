import {Component, EventEmitter, Output} from '@angular/core';
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

  @Output() isAdmin = new EventEmitter<boolean>();
  @Output() isLogged = new EventEmitter<boolean>();

  constructor(private dataService: DataService, private usersService: UsersService) { }

  setAdmin(value: boolean){
    this.isAdmin.emit(value);
  }

  setLogged(value: boolean){
    this.isLogged.emit(value);
  }

  checkCredentials(username: string, password: string): void{
    this.dataService.getLoginCredentials({username, password} as Login).subscribe(
      data =>
      {
        switch (data.userType) {
          case 'Client':
            this.getClientByEmail(username);
            this.setAdmin(false);
            this.setLogged(true);
            break;
          case 'Admin':
            this.usersService.admin = { username, password } as Admin;
            this.setAdmin(true);
            this.setLogged(true);
            break;
          case 'Invalid':
            this.setLogged(false);
            break;
        }
      });
  }

  getClientByEmail(email: string): void{
    this.dataService.getClientByEmail(email).subscribe(data => this.usersService.client = data);
  }

}
