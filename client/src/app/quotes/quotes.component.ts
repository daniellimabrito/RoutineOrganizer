import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

function GetQuote() {
  fetch('https://type.fit/api/quotes')
  .then((response) => {
    return response.json();
  })
  .then((data) => {
    console.log(data);
  });
}

@Component({
  selector: 'app-quotes',
  templateUrl: './quotes.component.html',
  styleUrls: ['./quotes.component.css']
})


export class QuotesComponent implements OnInit {

  url = 'https://type.fit/api/quotes';
  quotes: any;
  randomQuote: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getQuotes();
  }

  getQuotes() {
    return this.http.get(this.url).subscribe(response => {
      this.quotes = response;
     // console.log(this.quotes);
      const obj = JSON.stringify(this.quotes);
      this.getRandomQuote(obj);
    }, error => {
      console.log(error);
    }
    );
  }

  getRandomQuote(data) {
    const obj = JSON.parse(data);

    this.randomQuote = obj[Math.floor(Math.random() * obj.length)];
  }





}
