using InfocomTestTask.Interfaces;
using InfocomTestTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfocomTestTask.Controllers
{

    [ApiController]
    public class PersonController :Controller
    {
        private IPersonData personData;

        public PersonController(IPersonData PersonData)
        {
            personData = PersonData;
        }

        [HttpGet]
        [Route("[controller]/GetPeople")]
        public IActionResult GetPeople()
        {
            return Ok(personData.GetPeople());

        }

        [HttpGet]
        [Route("[controller]/SearchPerson")]
        public IActionResult Search(string name)
        {
            try
            {
                var result =  personData.Search(name);

                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
            return Ok(personData.GetPeople());

        }

        [HttpGet]
        [Route("[controller]/GetPerson")]
        public IActionResult GetPerson(Guid id)
        {
            var person = personData.GetPerson(id);

            if(person != null)
            {
                return Ok(person);
            }

            return NotFound("Not found");

        }

        [HttpPost]
        [Route("[controller]/AddPerson")]
        public IActionResult AddPerson(Person person)
        {
            personData.AddPerson(person);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + person.Id, person);
        }


        [HttpDelete]
        [Route("[controller]/DeletePerson")]
        public IActionResult DeletePerson(Guid Id)
        {
            var person = personData.GetPerson(Id);

            if(person != null)
            {
                personData.DeletePerson(person);
                return Ok();
            }

            return NotFound("Not Found");
        }

        [HttpPatch]
        [Route("[controller]/EditPerson")]
        public IActionResult EditPerson(Guid Id, Person person)
        {
            var _person = personData.GetPerson(Id);
            if (person != null)
            {
                 person.Id = _person.Id;
                personData.EditPerson(person);
            }
            return Ok(person);

        }

    }
}
