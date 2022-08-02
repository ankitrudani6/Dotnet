using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private DataHelper dataHelper { get; set; }

        public PersonController()
        {
            dataHelper = new DataHelper();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //HttpContext.Response.Headers.Add("Person List", "True");
            return Ok(await dataHelper.GetPersonList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await dataHelper.GetPerson(id);
            if (person == null)
                return NotFound($"Person with Id = {id} not found");
            return Ok(await dataHelper.GetPerson(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            var error = new List<string>();
            if (String.IsNullOrEmpty(person.FirstName)) error.Add("FirstName is Required");
            if (String.IsNullOrEmpty(person.LastName)) error.Add("LastName is Required");
            
            if (error.Count > 0) 
                return BadRequest(error);
            else 
                return Ok(await dataHelper.AddPerson(person));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Person person)
        {
            if (id != person.PersonId)
                return BadRequest("Person ID mismatch");
            var p = await dataHelper.GetPerson(id);
            if (p == null)
                return NotFound($"Person with Id = {id} not found");
            
            return Ok(await dataHelper.UpdatePerson(person));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, JsonPatchDocument<Person> patchPerson)
        {
            var person = await dataHelper.GetPerson(id);
            patchPerson.ApplyTo(person);

            return Ok(await dataHelper.UpdatePersonField(person));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var p = await dataHelper.GetPerson(id);
            if (p == null)
                return NotFound($"Person with Id = {id} not found");
            return Ok(await dataHelper.DeletePerson(id));
        }
    }
}
