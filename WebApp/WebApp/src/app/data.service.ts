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
import {Order} from './models/order';
import {NumberDto} from './models/number-dto';
import {Report} from './models/report';
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
  private regionsUrl = 'api/regions/';
  private orderUrl = 'api/orders/';
  private reportsUrl = 'api/reports/';
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

  getClientByEmail(email: string): Observable<Client> {
    this.messageService.add('DataService: fetched deviceTypes');
    return this.http.get<Client>(this.clientsUrl + email)
      .pipe(
        catchError(this.handleError<Client>('getClientByEmail', null))
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

  addOrder(order: Order): Observable<Order> {
    return this.http.post<Order>(this.orderUrl, order, this.httpOptions).pipe(
      tap((newOrder: Order) => this.log(`added order w/ consecutive=${order.consecutive} and bill_number=${order.bill_number}`)),
      catchError(this.handleError<Order>('addClient'))
    );
  }

  getAllContinents(): Observable<Region[]> {
    this.messageService.add('DataService: fetched continents');
    return this.http.get<Region[]>(this.regionsUrl + 'continents')
      .pipe(
        catchError(this.handleError<Region[]>('getAllContinents', []))
      );
  }

  getCountriesByContinent(continent: string): Observable<Region[]> {
    this.messageService.add('DataService: fetched countriesByContinent');
    return this.http.get<Region[]>(this.regionsUrl + 'countries/' + continent)
      .pipe(
        catchError(this.handleError<Region[]>('getAllContinents', []))
      );
  }

  getActiveDevices(): Observable<NumberDto> {
    this.messageService.add('DataService: fetched ActiveDevices');
    return this.http.get<NumberDto>(this.dashboardUrl + 'activeDevices')
      .pipe(
        catchError(this.handleError<NumberDto>('getActiveDevices', null))
      );
  }

  getDevicesPerUser(): Observable<DevicesPerUser> {
    this.messageService.add('DataService: fetched DevicesPerUser');
    return this.http.get<DevicesPerUser>(this.dashboardUrl + 'devicesPerUser')
      .pipe(
        catchError(this.handleError<DevicesPerUser>('getDevicesPerUser', null))
      );
  }

  getDevicesPerRegion(): Observable<Region[]> {
    this.messageService.add('DataService: fetched DevicesPerRegion');
    return this.http.get<Region[]>(this.dashboardUrl + 'DevicesPerRegion')
      .pipe(
        catchError(this.handleError<Region[]>('DevicesPerRegion', null))
      );
  }

  getMonthlyUsage(email: string): Observable<NumberDto> {
    this.messageService.add('DataService: fetched MonthlyUsage');
    return this.http.get<NumberDto>(this.reportsUrl + 'monthlyUsage/' + email)
      .pipe(
        catchError(this.handleError<NumberDto>('MonthlyUsage', null))
      );
  }

  getDeviceTypesUsage(email: string): Observable<Report[]> {
    return this.http.get<Report[]>(this.reportsUrl + 'deviceTypesUsage/' + email)
      .pipe(
        catchError(this.handleError<Report[]>('DeviceTypesUsage', null))
      );
  }

  getDailyUsage(email: string): Observable<Report[]> {
    return this.http.get<Report[]>(this.reportsUrl + 'dailyUsage/' + email)
      .pipe(
        catchError(this.handleError<Report[]>('DailyUsage', null))
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
