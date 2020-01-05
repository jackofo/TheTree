using Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheTree_Core.Models;

namespace TheTree_Infrastructure
{
	public class PersonService
	{
		public List<Person> ListAll()
		{
			using (var db = new ProjectContext())
			{
				List<Person> persons = db.Persons.ToList(); //new List<Person>
			//{
			//	new Person { Id = 2, Name = "Dupek", Surname = "Dupkowaty" },
			//	new Person { Id = 3, Name = "Pupek", Surname = "Pupkowaty" }
			//};

				return persons;
			}
		}

		public Person Get(int id)
		{
			//using var db = new ProjectContext();
			//return (Person)db.Persons.Where(p => p.Id == id);
			return new Person
			{
				Id = 1,
				Name = "Pajac",
				Surname = "innyPajac"
			};
		}

		public bool Post(Person person)
		{
			using (var db = new ProjectContext())
			{
				foreach(var p in ListAll())
				{
					if(p.Name == person.Name && p.Surname == person.Surname)
					{
						return false;
					}
				}
				db.Persons.Add(person);
				db.SaveChanges();
			}
			return true;
		}
	}
}
