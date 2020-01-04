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
  ls = false;
  persons : Person[];
  selectedPerson : Person;

  constructor(private service : PersonService)
  {
    this.persons = new Array<Person>();
    this.selectedPerson = new Person();
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
    console.log(this.selectedPerson);
  }

  public Add(person : Person)
  {
    this.service.Add(person).subscribe(response => console.log(response));
  }

  //testshit
  Click()
  {
    this.ListAll();
  }
  onSubmit(name : string, surname : string)
  {
    console.log("dupa");
    let p = new Person();
    p.Name = name;
    p.Surname = surname;
    p.Id = 2;
    this.Add(p);
  }
}


