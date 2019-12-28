import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Person } from '../_models/person';
import { HttpClientModule, HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class PersonService 
{
  constructor(private http: HttpClient) { }
  
  ListAll(): Observable<String[]>
  {
    return this.http.get<String[]>("localhost:5001//api/person/all")
  }
}
