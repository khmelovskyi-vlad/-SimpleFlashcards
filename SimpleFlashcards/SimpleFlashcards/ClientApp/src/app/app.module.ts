import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { GoodRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { MainModule } from './main/main.module';
import { NavbarModule } from './navbar/navbar.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    MainModule,
    NavbarModule,

    GoodRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
