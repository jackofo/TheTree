using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheTree_Core.Models;

namespace TheTree_API.Controllers
{
    [Route("/api/person")]
    [ApiController]
	[EnableCors("*")]
	public class PersonController : ControllerBase
	{
		static int t = 0;
		//GET: api/Person/all
		[HttpGet("all")]
		public IEnumerable<PersonDto> ListAll()
		{
			PersonDto[] persons = new PersonDto[2];
			PersonDto p1 = new PersonDto();
			p1.Id = 2;
			p1.Name = "aa";
			p1.Surname = "AA";
			PersonDto p2 = new PersonDto();
			p2.Id = 3;
			p2.Name = "bb";
			p2.Surname = "BB";
			persons[0] = p1;
			persons[1] = p2;
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
			t += id;
			Console.WriteLine(t);
			PersonDto p = new PersonDto();
			p.Id = 1;
			p.Name = "Json";
			p.Surname = "Data";
            return p;
        }

        // POST: api/Person
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
