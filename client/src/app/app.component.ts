import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client';
  data: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get('https://localhost:7243/api/Category').subscribe({
      next: response => {
        this.data = response;
        console.log(this.data);
      },
      error: err => console.error(err),
      complete: () => console.log('Request completed')
    });
    this.http.get('https://localhost:7243/api/Country').subscribe({
      next: response => {
        this.data = response;
        console.log(this.data);
      },
      error: err => console.error(err),
      complete: () => console.log('Request completed')
    });
    this.http.get('https://localhost:7243/api/Owner').subscribe({
      next: response => {
        this.data = response;
        console.log(this.data);
      },
      error: err => console.error(err),
      complete: () => console.log('Request completed')
    });
    this.http.get('https://localhost:7026/api/Review').subscribe({
      next: response => {
        this.data = response;
        console.log(this.data);
      },
      error: err => console.error(err),
      complete: () => console.log('Request completed')
    });
    this.http.get('https://localhost:7243/api/Reviewer').subscribe({
      next: response => {
        this.data = response;
        console.log(this.data);
      },
      error: err => console.error(err),
      complete: () => console.log('Request completed')
    });
  }
}
