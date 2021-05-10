import { Injectable } from '@angular/core';
import {Admin} from './models/admin';
import {Client} from './models/client';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  public admin: Admin;
  public client: Client;
  public userType: string;
  public isAdmin: boolean;
  public isLogged: boolean;
  constructor() { }


}
