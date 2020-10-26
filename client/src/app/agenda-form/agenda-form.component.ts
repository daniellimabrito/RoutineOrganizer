import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AgendaService } from '../_services/agenda.service';
import { Agenda } from '../_models/Agenda';
import { formatDate } from '@angular/common';
import { AlertifyService } from '../_services/alertify.service';
import { typeWithParameters } from '@angular/compiler/src/render3/util';

@Component({
  selector: 'app-agenda-form',
  templateUrl: './agenda-form.component.html',
  styleUrls: ['./agenda-form.component.css']
})
export class AgendaFormComponent implements OnInit {

  // agendas1: [ {id: '', name: '', notes: 'afsfs', period: '', activities: { id: '', day: '', interval: ''},
  //                projects: {id: '', description: ''}, priorities: {id: '', description: ''} , prouds: {id: '', description: ''}  }];

  agendas: Agenda;
  isUpdate: boolean;
  emptyId = '00000000-0000-0000-0000-000000000000';
  currentDate: any;

  constructor(private agendaService: AgendaService, private alertify: AlertifyService ) {}

  ngOnInit() {
    const obj: number = Date.now();
    const strDate = formatDate(obj, 'yyyy-MM-dd', 'en-US');
    console.log('Data: ' + strDate);
    this.onChangeDate(strDate);
  }


  onSubmit(form) {
    const agenda: Agenda = form.values;
    this.agendas = Object.assign({}, form);
    this.agendas.period = this.currentDate;

    console.log('submit');
    console.log(form);

    if (this.agendas.id === this.emptyId) {
      console.log('add');
      this.agendaService.addAgenda(this.agendas)
      .subscribe(
        success => this.alertify.success('Insert success'),
        error => this.alertify.error(error),
        () => this.onChangeDate(this.currentDate) );
    }
    else {
      console.log('update');

      this.agendaService.udpateAgenda(this.agendas)
      .subscribe(
        success => this.alertify.success('Update success'),
        error => this.alertify.error(error),
        () => console.log('Request completed') );

    }

  }

  onChangeDate(event: any) {
    console.log(event);

    this.agendaService.getAgendaByPeriod(event)
    .subscribe( data => {
      this.agendas = data;
      this.currentDate = event;
      console.log(data);
    }, error => {
      console.log(error);
    });
    console.log(this.agendas);

  }


}
