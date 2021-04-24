import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {

  /*orders: OrderInterface[] | undefined;
  topDishes: DishInterface[] | undefined;
  topClients: ClientInterface[] | undefined;
  topOrders: OrderInterface[] | undefined;
  constructor(private dataService: DataService) { }*/

  admin: boolean = true;

  ngOnInit(): void {
    this.getAllOrders();
    this.getBestSellingDishes();
  }

  // Funciones que sustituyen el inicio de seccion de un cheff o admin
  cheffLog() { this.admin = false; }
  adminLog() { this.admin = true; }

  getAllOrders(): void {
    //this.dataService.getAllOrders().subscribe(data => this.orders = data);
  }

  private getBestSellingDishes() {
    //this.dataService.getBestSellingDishes().subscribe(data => this.topDishes = data);
  }

  private getBestProfitDishes() {
 //   this.dataService.getBestProfitDishes().subscribe(data => this.topDishes = data);
  }

  private getOrdersByFeedback() {
   // this.dataService.getOrdersByFeedback().subscribe(data => this.topOrders = data);
  }

  private getBestClientsByOrders() {
//    this.dataService.getBestClientsByOrders().subscribe(data => this.topClients = data);
  }

  private takeOrder(idStr: string, chef: string) {
    const id = Number(idStr);
    const state = 'En progreso';
//    this.dataService.updateOrder({ id, state, chef } as OrderInterface).subscribe();
  }
}
