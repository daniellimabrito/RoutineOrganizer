import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AgendaFormComponent } from './agenda-form/agenda-form.component';
import { QuotesComponent } from './quotes/quotes.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { DatepickermonthComponent } from './datepickermonth/datepickermonth.component';


@NgModule({
  declarations: [
    AppComponent,
    AgendaFormComponent,
    QuotesComponent,
    DatepickermonthComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    HttpClientModule,
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
