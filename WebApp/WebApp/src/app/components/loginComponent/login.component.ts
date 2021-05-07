import { Component } from '@angular/core';
import {DataService} from '../../data.service';
import {Login} from '../../models/login';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'loginScreen',
  templateUrl: './login.component.html' ,
  styleUrls: ['./login.component.css']
})
// tslint:disable-next-line:component-class-suffix
export class LoginScreen {

  loginModel: Login;

  constructor(private dataService: DataService) { }

  checkCredentials(username: string, password: string): void{
    this.dataService.getLoginCredentials({username, password} as Login).subscribe( data => this.loginModel = data);
  }


}
