using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Core.Models;
using Infrastructure;
using Core.Interfaces;
using Core.Services;

namespace TheTree_API.Controllers
{
    [Route("/api/person")]
    [ApiController]
	[EnableCors]
	public class PersonController : ControllerBase
	{
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        //GET: api/Person/all
        [HttpGet("all")]
		public async Task<IEnumerable<PersonDto>> ListAllAsync()
		{
            var persons = await _personService.ListAll();
            //foreach(var p in new PersonService().ListAll())
            //{
            //    persons.Add(new PersonDto(p));
            //}

            return persons;
		}
    }
}
