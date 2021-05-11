import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dasboard',
  templateUrl: './dasboard.component.html',
  styleUrls: ['./dasboard.component.css']
})
export class DasboardComponent implements OnInit {

  switchTables = true;

  constructor() { }

  ngOnInit(): void {

  }

  clickTD() {
    this.switchTables = true;
  }

  clickDPU() {
    this.switchTables = false;
  }

}
