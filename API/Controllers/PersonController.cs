﻿using System;
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
        private readonly Core.Services.IPersonService _personService;

        public PersonController(Core.Services.IPersonService personService)
        {
            _personService = personService;
        }

        //GET: api/Person/all
        [HttpGet("all")]
		public async Task<IEnumerable<PersonDto>> ListAllAsync()
		{
            List<PersonDto> persons = await _personService.ListAll();
            //foreach(var p in new PersonService().ListAll())
            //{
            //    persons.Add(new PersonDto(p));
            //}

            return persons;
		}

        // GET: api/Person
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public PersonDto Get(int id)
        {
            Person p = new Core.Services.IPersonService().Get(id);
			PersonDto pDto = new PersonDto(p);
            return pDto;
        }

        // POST: api/Person
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Console.WriteLine(value);
        }

        // POST: api/Person/send
        [HttpPost("send")]
        public IActionResult PostPerson([FromBody] object value)
        {
            PersonDto p = JsonConvert.DeserializeObject<PersonDto>(value.ToString());
            if (new Core.Services.IPersonService().Post(p.ToPerson()))
            {
                return base.Ok();
            }
            else
            {
                return base.StatusCode(304);
            }
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public void Put([FromBody] PersonDto value)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
