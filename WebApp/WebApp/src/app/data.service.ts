import { Injectable } from '@angular/core';
import {Observable, of} from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {MessageService} from './message.service';
import {DeviceType} from './models/device-type';
import {Device} from './models/device';
import {Login} from './models/login';
import {Client} from './models/client';
import {Distributor} from './models/distributor';
import {Region} from './models/region';
import {DirectionClient} from './models/direction-client';
import {DevicesPerUser} from './models/devices-per-user';
@Injectable({
  providedIn: 'root'
})
export class DataService {

  private deviceTypesUrl = 'api/devicetypes/';
  private devicesUrl = 'api/devices/';
  private clientsUrl = 'api/clients/';
  private onlineStoreUrl = 'api/onlinestore/';
  private dashboardUrl = 'api/dashboard/';
  private loginUrl = 'api/login/';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient, private  messageService: MessageService) { }

  getAllDeviceTypes(): Observable<DeviceType[]> {
    this.messageService.add('DataService: fetched deviceTypes');
    return this.http.get<DeviceType[]>(this.deviceTypesUrl)
      .pipe(
        catchError(this.handleError<DeviceType[]>('getAllDeviceTypes', []))
      );
  }

  addDeviceType(deviceType: DeviceType): Observable<DeviceType> {
    return this.http.post<DeviceType>(this.deviceTypesUrl, deviceType, this.httpOptions).pipe(
      tap((newDeviceType: DeviceType) => this.log(`added deviceType w/ name=${newDeviceType.name}`)),
      catchError(this.handleError<DeviceType>('addDeviceType'))
    );
  }

  updateDeviceType(deviceType: DeviceType): Observable<DeviceType> {
    return this.http.put<DeviceType>(this.deviceTypesUrl + deviceType.name, deviceType, this.httpOptions).pipe(
      catchError(this.handleError<DeviceType>('updateDish'))
    );
  }

  deleteDeviceType(deviceTypeName: string): Observable<{}> {
    return this.http.delete(this.deviceTypesUrl + deviceTypeName, this.httpOptions).pipe(
      catchError(this.handleError('deleteDeviceType'))
    );
  }

  getAllDevices(): Observable<Device[]> {
    this.messageService.add('DataService: fetched devices');
    return this.http.get<Device[]>(this.devicesUrl)
      .pipe(
        catchError(this.handleError<Device[]>('getAllDevices', []))
      );
  }

  addDevice(device: Device): Observable<Device> {
    return this.http.post<Device>(this.devicesUrl, device, this.httpOptions).pipe(
      tap((newDevice: Device) => this.log(`added device w/ serial_number=${newDevice.serial_number}`)),
      catchError(this.handleError<Device>('addDevice'))
    );
  }

  updateDevice(device: Device): Observable<Device> {
    return this.http.put<Device>(this.devicesUrl + device.serial_number, device, this.httpOptions).pipe(
      catchError(this.handleError<Device>('updateDevice'))
    );
  }

  deleteDevice(deviceSerialNumber: number): Observable<{}> {
    return this.http.delete(this.devicesUrl + deviceSerialNumber, this.httpOptions).pipe(
      catchError(this.handleError('deleteDevice'))
    );
  }

  addClient(client: Client): Observable<Client> {
    return this.http.post<Client>(this.clientsUrl, client, this.httpOptions).pipe(
      tap((newClient: Client) => this.log(`added client w/ email=${newClient.email}`)),
      catchError(this.handleError<Client>('addClient'))
    );
  }

  updateClient(client: Client): Observable<Client> {
    return this.http.put<Client>(this.clientsUrl + client.email, client, this.httpOptions).pipe(
      tap((newClient: Client) => this.log(`updated device w/ email=${newClient.email}`)),
      catchError(this.handleError<Client>('updateClient'))
    );
  }

  addDirectionClient(directionClient: DirectionClient): Observable<DirectionClient> {
    return this.http.post<DirectionClient>(this.clientsUrl + 'direction', directionClient, this.httpOptions).pipe(
      tap((newDirectionClient: DirectionClient) => this.log(`added directionClient w/ email=${newDirectionClient.client_email}`)),
      catchError(this.handleError<DirectionClient>('addDirectionClient'))
    );
  }

  getLoginCredentials(loginCred: Login): Observable<Login>
  {
    return this.http.post<Login>(this.loginUrl, loginCred, this.httpOptions).pipe(
      tap((logCredentials: Login) => this.log(`usertype logged: ${logCredentials.userType}`)),
      catchError(this.handleError<Login>('getLoginCredentials'))
    );
  }

  getOnlineStore(region: Region): Observable<Distributor[]> {
    return this.http.post<Distributor[]>(this.onlineStoreUrl + 'distributors', region, this.httpOptions).pipe(
      tap((newOnlineStore: Distributor[]) => this.log(`obtained online store`)),
      catchError(this.handleError<Distributor[]>('getOnlineStore'))
    );
  }

  addOnlineStore(distributors: Distributor[]): Observable<Distributor[]> {
    return this.http.post<Distributor[]>(this.onlineStoreUrl, distributors, this.httpOptions).pipe(
      tap((newOnlineStore: Distributor[]) => this.log(`created new online store`)),
      catchError(this.handleError<Distributor[]>('addClient'))
    );
  }

  getActiveDevices(): Observable<number> {
    this.messageService.add('DataService: fetched ActiveDevices');
    return this.http.get<number>(this.dashboardUrl + 'activeDevices')
      .pipe(
        catchError(this.handleError<number>('getAllDevices', -1))
      );
  }

  getDevicesPerUser(): Observable<DevicesPerUser> {
    this.messageService.add('DataService: fetched DevicesPerUser');
    return this.http.get<DevicesPerUser>(this.dashboardUrl + 'devicesPerUser')
      .pipe(
        catchError(this.handleError<DevicesPerUser>('getDevicesPerUser', null))
      );
  }

  // tslint:disable-next-line:typedef
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  // tslint:disable-next-line:typedef
  private log(message: string) {
    this.messageService.add(`DataService: ${message}`);
  }


}
