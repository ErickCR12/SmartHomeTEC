import { Component, OnInit } from '@angular/core';
import * as XLSX from 'xlsx';
import { Device } from '../../models/device';
import { Distributor } from '../../models/distributor';
import {DataService} from '../../data.service';

@Component({
  selector: 'app-uploadpage',
  templateUrl: './uploadpage.component.html',
  styleUrls: ['./uploadpage.component.css']
})
export class UploadpageComponent implements OnInit {

  data: [][][];
  devicesOffered: Device[];
  distributorsRegs: Distributor[];

  constructor(private dataService: DataService) { }


  ngOnInit(): void {
  }

  onFileChange(evt: any) {
    const target: DataTransfer = <DataTransfer>(evt.target);

    if (target.files.length !== 1) throw new Error('Cannot use multiple files');

    const reader: FileReader = new FileReader();

    reader.onload = (e: any) => {
      const bstr: string = e.target.result;

      const wb: XLSX.WorkBook = XLSX.read(bstr, { type: 'binary' });

      const wsname: string = wb.SheetNames[0];

      const ws: XLSX.WorkSheet = wb.Sheets[wsname];

      this.data = (XLSX.utils.sheet_to_json(ws, { header:1 } ));

      this.distributorsRegs = [];
      for (let i in this.data) {

        var legal_id = this.data[i][0].toString();

        this.devicesOffered = [];

        //se crea un un device por cada numero de serie:
        for (let j in this.data[i].slice(1)) {//por cada intem despues del primero
          var serial_number = this.data[i].slice(1)[j].toString();//se convierte a string el item
          const new_device = { serial_number: Number(serial_number) } as Device;
          //Se agrega el device a la lista de Devices del distro
          var cache = this.devicesOffered.push(new_device);
        };
        const new_Distro = { legal_card: Number(legal_id), devices: this.devicesOffered } as Distributor;

        var trash = this.distributorsRegs.push(new_Distro);

      }

      console.log(this.distributorsRegs);

    };
    reader.readAsBinaryString(target.files[0]);
  }


  uploadDocs() {
    this.dataService.addOnlineStore(this.distributorsRegs).subscribe();
  }




}
