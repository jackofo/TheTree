import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Relationship } from '../_models/relationship';

@Injectable({
  providedIn: 'root'
})

export class RelationshipService 
{
  constructor() { }

  public ListAll(): Observable<Relationship[]>
  {
    return;
  }
}
