import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LoginScreen } from './components/loginComponent/login.component';
import { RegisterComponent } from './components/register-component/register-component.component';
import { EditProfileComponent } from './components/edit-profile/edit-profile.component';
import { ShopComponent } from './components/shop/shop.component';
import { ReportsComponent } from './components/reports/reports.component';
import { DeviceMaganerComponent } from './components/device-maganer/device-maganer.component';
import { DevicesComponent } from './components/devices/devices.component';
import { DeviceTableComponent } from './components/device-table/device-table.component';
import { UploadpageComponent } from './components/uploadpage/uploadpage.component';
import { UsageTableComponent } from './components/usage-table/usage-table.component';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    LoginScreen,
    RegisterComponent,
    EditProfileComponent,
    ShopComponent,
    ReportsComponent,
    DeviceMaganerComponent,
    DevicesComponent,
    DeviceTableComponent,
    UploadpageComponent,
    UsageTableComponent,

  ],
    imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule
    ],
  providers: [],
  bootstrap: [AppComponent, LoginScreen]
})
export class AppModule { }
