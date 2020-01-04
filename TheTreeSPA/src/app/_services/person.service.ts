import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Person } from '../_models/person';
import { HttpClientModule, HttpClient, HttpHeaders } from '@angular/common/http';
import { Result } from '../_components/person/result';

@Injectable({
  providedIn: 'root'
})

export class PersonService 
{
  url : string = "https://localhost:44372/api/person";

  constructor(private http: HttpClient) { }
  
  ListAll(): Observable<Person[]>
  {
    return this.http.get<Person[]>(this.url + "/all");
  }

  Get(id : number) : Observable<Person>
  {
    return this.http.get<Person>(this.url + "/" + id);
  }

  Add(person : Person) : Observable<any>
  {
    const httpOptions = 
    {
      headers: new HttpHeaders({"Content-Type": "application/json"})
    }

    let urlS = this.url + "/send";

    return this.http.post<Person>(urlS, person, httpOptions);
  }
}
// ,
//         'Access-Control-Request-Method': 'POST',
//         'Access-Control-Request-Headers': 'authorization'