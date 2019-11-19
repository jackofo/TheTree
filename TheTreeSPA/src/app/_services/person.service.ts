import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Person } from '../_models/person';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor() { }
  
  public ListAll(): Observable<Person[]>
  {
    return;
  }
}
