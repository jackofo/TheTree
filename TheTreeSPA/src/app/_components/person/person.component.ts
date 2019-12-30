import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../_services/person.service';
import { Person } from '../../_models/person';
import { Observable } from 'rxjs';
import { validateConfig } from '@angular/router/src/config';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.scss']
})

export class PersonComponent implements OnInit 
{
  a :string = "kasza";
  ls = false;
  persons : Person[];
  selectedPerson : Person;
  p : Person;

  constructor(private service : PersonService)
  {
    this.persons = new Array<Person>();
    this.selectedPerson = new Person();
    this.p = new Person();
    this.p.id =1;
  }

  ngOnInit() 
  {
    
  }

  Update()
  {
    this.ls = true;
  } 

  public ListAll()
  {
    this.service.ListAll().subscribe(response => { this.persons = response; this.Update(); });
  }

  public Get()
  {
    this.service.Get(1).subscribe(response => { this.selectedPerson = response; });
  }

  Click()
  {
    this.ListAll();
  }
}


