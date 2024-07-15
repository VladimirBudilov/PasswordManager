import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { PasswordListComponent } from './components/password-list/password-list.component';
import { PasswordModalComponent } from './components/password-modal/password-modal.component';
import {RouterOutlet} from "@angular/router";

@NgModule({
  declarations: [
    AppComponent,
    PasswordListComponent,
    PasswordModalComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterOutlet
  ],
  exports: [
    PasswordModalComponent
  ],
  providers: [],
  bootstrap: [PasswordListComponent]
})
export class AppModule { }
