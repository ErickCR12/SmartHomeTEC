import { Injectable } from '@angular/core';
import {Observable, of} from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {MessageService} from './message.service';
import {DeviceType} from './models/device-type';
@Injectable({
  providedIn: 'root'
})
export class DataService {

  private deviceTypesUrl = '/api/deviceTypes/';
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
  //
  // addDish(dish: DishInterface): Observable<DishInterface> {
  //   return this.http.post<DishInterface>(this.dishesUrl, dish, this.httpOptions).pipe(
  //     tap((newDish: DishInterface) => this.log(`added dish w/ id=${newDish.id}`)),
  //     catchError(this.handleError<DishInterface>('addDish'))
  //   );
  // }
  //
  // updateDish(dish: DishInterface): Observable<DishInterface> {
  //   return this.http.put<DishInterface>(this.dishesUrl + dish.id, dish, this.httpOptions).pipe(
  //     tap((newDish: DishInterface) => this.log(`updated dish w/ id=${newDish.id}`)),
  //     catchError(this.handleError<DishInterface>('updateDish'))
  //   );
  // }
  //
  // deleteDish(dishId: number): Observable<{}> {
  //   // @ts-ignore
  //   return this.http.delete(this.dishesUrl + dishId, this.httpOptions).pipe(
  //     catchError(this.handleError('deleteDish'))
  //   );
  // }
  //
  // getAllMenus(): Observable<MenuInterface[]> {
  //   this.messageService.add('DataService: fetched menus');
  //   return this.http.get<MenuInterface[]>(this.menusUrl)
  //     .pipe(
  //       catchError(this.handleError<MenuInterface[]>('getAllMenus', []))
  //     );
  // }
  //
  // addMenu(menu: MenuInterface): Observable<MenuInterface> {
  //   return this.http.post<MenuInterface>(this.menusUrl, menu, this.httpOptions).pipe(
  //     tap((newMenu: MenuInterface) => this.log(`added menu w/ id=${newMenu.id}`)),
  //     catchError(this.handleError<MenuInterface>('addMenu'))
  //   );
  // }
  //
  // updateMenu(menu: MenuInterface): Observable<MenuInterface> {
  //   return this.http.put<MenuInterface>(this.menusUrl + menu.id, menu, this.httpOptions).pipe(
  //     tap((newMenu: MenuInterface) => this.log(`updated menu w/ id=${newMenu.id}`)),
  //     catchError(this.handleError<MenuInterface>('updateMenu'))
  //   );
  // }
  //
  // deleteMenu(menuId: number): Observable<{}> {
  //   // @ts-ignore
  //   return this.http.delete(this.menusUrl + menuId, this.httpOptions).pipe(
  //     catchError(this.handleError('deleteMenu'))
  //   );
  // }
  //
  // getAllOrders(): Observable<OrderInterface[]> {
  //   this.messageService.add('DataService: fetched orders');
  //   return this.http.get<OrderInterface[]>(this.ordersUrl)
  //     .pipe(
  //       catchError(this.handleError<OrderInterface[]>('getAllOrders', []))
  //     );
  // }
  //
  // getOrderByChef(email: string): Observable<OrderInterface[]> {
  //   this.messageService.add('DataService: fetched orders');
  //   return this.http.get<OrderInterface[]>(this.ordersUrl + email)
  //     .pipe(
  //       catchError(this.handleError<OrderInterface[]>('getOrdersByChef', []))
  //     );
  // }
  //
  // updateOrder(order: OrderInterface): Observable<OrderInterface> {
  //   return this.http.put<OrderInterface>(this.ordersUrl + order.id, order, this.httpOptions).pipe(
  //     tap((newOrder: OrderInterface) => this.log(`updated order w/ id=${newOrder.id}`)),
  //     catchError(this.handleError<OrderInterface>('updateOrder'))
  //   );
  // }
  //
  // deleteOrder(orderId: number): Observable<{}> {
  //   // @ts-ignore
  //   return this.http.delete(this.ordersUrl + orderId, this.httpOptions).pipe(
  //     catchError(this.handleError('deleteOrder'))
  //   );
  // }
  //
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
  //
  // getBestSellingDishes(): Observable<DishInterface[]> {
  //   this.messageService.add('DataService: fetched best selling dishes');
  //   return this.http.get<DishInterface[]>(this.reportsUrl + 'topselling')
  //     .pipe(
  //       catchError(this.handleError<DishInterface[]>('getAllDishes', []))
  //     );
  // }
  //
  // getBestProfitDishes(): Observable<DishInterface[]> {
  //   this.messageService.add('DataService: fetched best profit dishes');
  //   return this.http.get<DishInterface[]>(this.reportsUrl + 'topprofit')
  //     .pipe(
  //       catchError(this.handleError<DishInterface[]>('getBestProfitDishes', []))
  //     );
  // }
  //
  // getBestClientsByOrders(): Observable<ClientInterface[]> {
  //   this.messageService.add('DataService: fetched top clients by amount of orders');
  //   return this.http.get<ClientInterface[]>(this.reportsUrl + 'topclients')
  //     .pipe(
  //       catchError(this.handleError<ClientInterface[]>('getBestClientsByOrders', []))
  //     );
  // }
  //
  // getOrdersByFeedback(): Observable<OrderInterface[]> {
  //   this.messageService.add('DataService: fetched top orders by feedback score');
  //   return this.http.get<OrderInterface[]>(this.reportsUrl + 'toporders')
  //     .pipe(
  //       catchError(this.handleError<OrderInterface[]>('getOrdersByFeedback', []))
  //     );
  // }
  //
  // getLoginCredentials(loginCred: LoginInterface): Observable<LoginInterface>
  // {
  //   return this.http.post<LoginInterface>(this.loginUrl, loginCred, this.httpOptions).pipe(
  //     tap((logCredentials: LoginInterface) => this.log(`usertype logged: ${logCredentials.userType}`)),
  //     catchError(this.handleError<LoginInterface>('getLoginCredentials'))
  //   );
  // }
  //
  // tslint:disable-next-line:typedef
  private log(message: string) {
    this.messageService.add(`DataService: ${message}`);
  }


}
