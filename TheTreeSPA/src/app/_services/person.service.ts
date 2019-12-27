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
  
  public ListAll(): Observable<any>
  {
    return this.http.get("localhost//api/person/all");
  }
}
