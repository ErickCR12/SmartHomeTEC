import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LoginScreen } from './components/loginComponent/login.component';
import { RegisterComponent } from './components/register-component/register-component.component';
import { EditProfileComponent } from './components/edit-profile/edit-profile.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginScreen,
    RegisterComponent,
    EditProfileComponent,
    
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent, LoginScreen]
})
export class AppModule { }
