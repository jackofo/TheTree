using System;
using System.Collections.Generic;
using System.Text;
using TheTree_Core.Models;

namespace Core.Dto
{
	public class PersonDto : BaseDto
	{
		public string Name { get; set; }
		public string Surname { get; set; }

		public PersonDto(){}

		public PersonDto(Person person)
		{
			this.Id = person.Id;
			this.Name = person.Name;
			this.Surname = person.Surname;
		}

		public Person ToPerson()
		{
			return new Person
			{
				//Id = this.Id,
				Name = this.Name,
				Surname = this.Surname
			};
		}
	}
}
