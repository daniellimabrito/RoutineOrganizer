import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AgendaService } from '../_services/agenda.service';
import { Agenda } from '../_models/Agenda';
import { formatDate } from '@angular/common';
import { AlertifyService } from '../_services/alertify.service';
import { typeWithParameters } from '@angular/compiler/src/render3/util';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-agenda-form',
  templateUrl: './agenda-form.component.html',
  styleUrls: ['./agenda-form.component.css']
})
export class AgendaFormComponent implements OnInit {

  agendaForm: FormGroup;
  agendas: Agenda;
  isUpdate: boolean;
  emptyId = '00000000-0000-0000-0000-000000000000';
  currentDate: any;
  isDeleteMode: boolean;
  id: string;

  emptyAgenda: Agenda = { id : this.emptyId, name : '', activities : '', priorities : '', projects : '', notes : '', period: ''};

  constructor(private agendaService: AgendaService, private alertify: AlertifyService, private route: ActivatedRoute,
              private fbAgenda: FormBuilder ) {}

  ngOnInit() {

    this.createAgendaForm();
    const obj: number = Date.now();
    const strDate = formatDate(obj, 'yyyy-MM-dd', 'en-US');
   // console.log('Data: ' + strDate);
    this.onChangeDate(strDate);
  }

  createAgendaForm() {
    this.agendaForm = this.fbAgenda.group({
      id: [this.emptyId],
      name: [''],
      notes: [null],
      activities: [null],
      projects: [null],
      prouds: [null],
      priorities: [null]
    });
  }

  onSubmit() {
   // const agenda: Agenda = this.agendaForm.value;
    this.agendas = Object.assign({}, this.agendaForm.value);
    this.agendas.period = this.currentDate;

    if (this.agendas.id === this.emptyId) {
        this.agendaService.addAgenda(this.agendas)
        .subscribe(
          success => this.alertify.success('Insert success'),
          error => this.alertify.error(error),
          () => this.onChangeDate(this.currentDate) );
      }
      else {
        this.agendaService.udpateAgenda(this.agendas)
        .subscribe(
          success => this.alertify.success('Update success'),
          error => this.alertify.error(error),
          () => this.onChangeDate(this.currentDate) );
      }
  }

  onChangeDate(event: any) {
    this.agendaService.getAgendaByPeriod(event)
    .subscribe( data => {
      if (data == null) {
        data = this.emptyAgenda;
      }
      this.agendas = data;
      this.currentDate = event;
      this.agendaForm.reset(this.agendas);
    }, error => {
      console.log(error);
    });
  }

  deleteAgenda() {

    this.alertify.confirm('Are you sure that you want to delete it?',
        () => this.agendaService.deleteAgenda(this.agendas.id)
      .subscribe(
        success => {
          this.alertify.success('Delete success');
          this.isDeleteMode = true;
        },
        error => {
          console.log(error);
          this.alertify.error(error);
        },
        () => {
          this.agendas = this.emptyAgenda;
          this.onChangeDate(this.currentDate);
        }
      ));
  }


}
