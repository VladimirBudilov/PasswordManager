import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { MatRadioModule } from '@angular/material/radio';
import {PasswordListComponent} from "./components/password-list/password-list.component";
import {PasswordModalComponent} from "./components/password-modal/password-modal.component";
import {AppComponent} from "./app.component";
import {BrowserModule} from "@angular/platform-browser";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {NgModule} from "@angular/core";
import {RouterOutlet} from "@angular/router";
import { MatSnackBarModule } from '@angular/material/snack-bar';

@NgModule({
  declarations: [
    AppComponent,
    PasswordModalComponent,
    PasswordListComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule,
    MatTableModule,
    MatDialogModule,
    MatRadioModule,
    RouterOutlet,
    MatSnackBarModule,
  ],
  providers: [],
  bootstrap: [PasswordListComponent]
})
export class AppModule { }
