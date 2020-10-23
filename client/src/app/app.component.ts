import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'DLB Orginizer';
  baseUrl = environment.apiUrl + 'agenda/';
  agendas: any;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getAgendas();
    console.log('AppComponent agenda:');
    console.log(this.agendas);
  }

  getAgendas() {
    return this.http.get(this.baseUrl).subscribe(response => {
      this.agendas = response;
    }, error => {
      console.log(error);
    }
    );
  }

}
