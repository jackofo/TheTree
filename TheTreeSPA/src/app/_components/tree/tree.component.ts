import { Component, OnInit } from '@angular/core';
import { Person } from 'src/app/_models/person';
import { PersonService } from 'src/app/_services/person.service';

@Component({
  selector: 'app-tree',
  templateUrl: './tree.component.html',
  styleUrls: ['./tree.component.scss']
})
export class TreeComponent implements OnInit 
{
  persons : Person[];

  constructor(private service : PersonService)
  {
    this.persons = new Array<Person>();
  }

  ngOnInit() 
  {
    this.ListAll();
  }
  
  public ListAll()
  {
    this.service.ListAll().subscribe(response => { this.persons = response; });
  }

}
