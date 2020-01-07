using Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Models;
using Core.Interfaces;
using System.Threading.Tasks;
using Core.Specifications;

namespace Core.Services
{
	public class IPersonService
	{
		//private readonly IHttpContextAccessor _httpContextAccessor;
		//private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		private readonly string _userId;

		public IPersonService(
			IUnitOfWork unitOfWork
			//IMapper mapper,
			//IHttpContextAccessor httpContextAccessor
			)
		{
			_unitOfWork = unitOfWork;
			//_mapper = mapper;
			//_httpContextAccessor = httpContextAccessor;
			//_userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
		}

		public async Task<IReadOnlyList<PersonDto>> ListAll()
		{

			IReadOnlyList<Person> output = await _unitOfWork.RepositoryAsync<Person>().ListAsync(new PersonSpecification());
			//TODO: tu konwersja z list<Person> na List<PersonDto>
			var persons = new List<PersonDto>();
			return persons;
		}
	}

	public Person Get(int id)
	{
		//using var db = new ProjectContext();
		//return (Person)db.Persons.Where(p => p.Id == id);
		return new Person
		{
			Id = Guid.NewGuid(),
			Name = "Pajac",
			Surname = "innyPajac"
		};
	}

	public bool Post(Person person)
	{
		//using (var db = new ProjectContext())
		//{
		//	foreach(var p in ListAll())
		//	{
		//		if(p.Name == person.Name && p.Surname == person.Surname)
		//		{
		//			return false;
		//		}
		//	}
		//	db.Persons.Add(person);
		//	db.SaveChanges();
		//}
		return true;
	}
}

