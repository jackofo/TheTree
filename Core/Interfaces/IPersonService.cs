using Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPersonService
    {
        Task<IReadOnlyList<PersonDto>> ListAll();
        Task<IReadOnlyList<PersonDto>> List(Guid id);
        //Task<PersonDetailsDto> GetDetails(Guid personId);
        //Task<PersonDetailsDto> AddPerson(Guid personId);
        //Task<PersonDetailsDto> EditPerson(Guid personId);
        //Task<PersonDetailsDto> DeletePerson(Guid personId);
    }
}
