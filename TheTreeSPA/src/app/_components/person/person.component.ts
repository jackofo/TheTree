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
  selectedPerson : Person;

  constructor(private service : PersonService)
  {
    this.selectedPerson = new Person();
  }

  ngOnInit() 
  {
    
  }

  public Get()
  {
    this.service.Get(1).subscribe(response => { this.selectedPerson = response; });
    console.log(this.selectedPerson);
  }
}


