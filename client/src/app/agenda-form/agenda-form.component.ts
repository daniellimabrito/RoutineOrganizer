import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AgendaService } from '../_services/agenda.service';
import { Agenda } from '../_models/Agenda';
import { formatDate } from '@angular/common';

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

  constructor(private agendaService: AgendaService ) {}

  ngOnInit() {
    const obj: number = Date.now();
    const strDate = formatDate(obj, 'yyyy-MM-dd', 'en-US');
    console.log('Data: ' + strDate);
    this.onChangeDate(strDate);
  }


  onSubmit(form) {
    const agenda: Agenda = form.values;
    console.log(agenda.priorities);
    if (agenda.id === this.emptyId) {
      console.log('add');
      this.agendaService.addAgenda(agenda);
    }
    else {
      console.log('update');

      this.agendaService.udpateAgenda(agenda);

    }

    console.log(agenda);
  }

  onChangeDate(event: any) {
    console.log(event);

    this.agendaService.getAgendaByPeriod(event)
    .subscribe( data => {
      this.agendas = data;
      console.log(data);
    }, error => {
      console.log(error);
    });
    console.log(this.agendas);

  }


}
