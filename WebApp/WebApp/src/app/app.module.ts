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
import { MessagesComponent } from './messages/messages.component';

import {HttpClientModule} from '@angular/common/http';

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
    MessagesComponent,

  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent, LoginScreen]
})
export class AppModule { }
