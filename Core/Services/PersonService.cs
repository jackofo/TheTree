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
	public class PersonService: IPersonService
	{
		//private readonly IHttpContextAccessor _httpContextAccessor;
		//private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		private readonly string _userId;

		public PersonService(
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

		public Task<IReadOnlyList<PersonDto>> List(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<IReadOnlyList<PersonDto>> ListAll()
		{

			IReadOnlyList<Person> output = await _unitOfWork.RepositoryAsync<Person>().ListAsync(new PersonSpecification());
			//TODO: tu konwersja z list<Person> na List<PersonDto>
			IReadOnlyList<PersonDto> persons = new List<PersonDto>();
			return persons;
		}
	}
}

