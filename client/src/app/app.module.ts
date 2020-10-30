import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AgendaFormComponent } from './agenda-form/agenda-form.component';
import { QuotesComponent } from './quotes/quotes.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { DatepickermonthComponent } from './datepickermonth/datepickermonth.component';
import { AgendaService } from './_services/agenda.service';
import { DatePipe } from '@angular/common';
import { FormDebugComponent } from './form-debug/form-debug.component';


@NgModule({
  declarations: [
    AppComponent,
    AgendaFormComponent,
    QuotesComponent,
    DatepickermonthComponent,
    FormDebugComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot()
  ],
  providers: [AgendaService, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
