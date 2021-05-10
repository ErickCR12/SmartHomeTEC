import { Injectable } from '@angular/core';
import {Admin} from './models/admin';
import {Client} from './models/client';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  get userType(): string {
    return this._userType;
  }

  set userType(value: string) {
    this._userType = value;
  }
  get client(): Client {
    return this._client;
  }

  set client(value: Client) {
    this._client = value;
  }

  admin: Admin;
  private _client: Client;
  private _userType: string;
  constructor() { }
}
