import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AgendaService } from '../_services/agenda.service';
import { Agenda } from '../_models/Agenda';

@Component({
  selector: 'app-agenda-form',
  templateUrl: './agenda-form.component.html',
  styleUrls: ['./agenda-form.component.css']
})
export class AgendaFormComponent implements OnInit {

  // agendas1: [ {id: '', name: '', notes: 'afsfs', period: '', activities: { id: '', day: '', interval: ''},
  //                projects: {id: '', description: ''}, priorities: {id: '', description: ''} , prouds: {id: '', description: ''}  }];

  agendas: Agenda;

  constructor(private agendaService: AgendaService ) {}

  ngOnInit() {
    this.agendaService.getAgendaById('445d26da-3b1f-4a95-8649-7198973c165c')
      .subscribe( data => {
        this.agendas = data;
        console.log(data);
      }, error => {
        console.log(error);
      });
    console.log(this.agendas);
  }


  onSubmit(form) {
    console.log(form);
  }

}
