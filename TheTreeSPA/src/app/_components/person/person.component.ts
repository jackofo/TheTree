import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../_services/person.service';
import { Person } from '../../_models/person';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.scss']
})

export class PersonComponent implements OnInit 
{
  persons : String[];
  selectedPerson : Person;

  constructor(private service : PersonService)
  {
    this.persons = new Array<String>();
  }

  ngOnInit() 
  {
  }

  public ListAll()
  {
    this.service.ListAll().subscribe(response => {this.persons = response;}, err => {console.log(err.message)});
  }
}


