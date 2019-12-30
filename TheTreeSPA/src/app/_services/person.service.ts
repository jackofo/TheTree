import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Person } from '../_models/person';
import { HttpClientModule, HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class PersonService 
{
  url : string = "https://localhost:44372/api/person/";

  constructor(private http: HttpClient) { }
  
  ListAll(): Observable<Person[]>
  {
    return this.http.get<Person[]>(this.url + "all");
  }

  Get(id : number) : Observable<any>
  {
    return this.http.get(this.url + id);
  }
}
