using ASPNetCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPNetCoreWebAPI.Controllers
{
    [ApiController]
    [Route("person")]
    public class PersonController : ControllerBase
    {
        static public List<Person> people = new List<Person>();

        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return Ok(people);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Person> Get(int id)
        {
            if(id>=0 && id < people.Count)
            {
                return Ok(people[id]);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody]Person person)
        {
            people.Add(person);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            people.RemoveAt(id);
            return Ok();
        }

    }
}
