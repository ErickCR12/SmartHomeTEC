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
import { DevicesPerUserComponent } from './components/devices-per-user/devices-per-user.component';
import { UploadpageComponent } from './components/uploadpage/uploadpage.component';
import { DeviceListTableComponent } from './components/device-list-table/device-list-table.component';
import { DasboardComponent } from './components/dasboard/dasboard.component';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import {MessagesComponent} from './messages/messages.component';
import {UsersService} from './users.service';
import { DevicesPerRegionComponent } from './components/devices-per-region/devices-per-region.component';
import { DeviceTypesUsageComponent } from './components/device-types-usage/device-types-usage.component';
import { DeviceDailyUsageComponent } from './components/device-daily-usage/device-daily-usage.component';


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
    DevicesPerUserComponent,
    UploadpageComponent,
    DeviceListTableComponent,
    MessagesComponent,
    DasboardComponent,
    DevicesPerRegionComponent,
    DeviceTypesUsageComponent,
    DeviceDailyUsageComponent,

  ],
    imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule
    ],
  providers: [UsersService],
  bootstrap: [AppComponent, LoginScreen]
})
export class AppModule { }
