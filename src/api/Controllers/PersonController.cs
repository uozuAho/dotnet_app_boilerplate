using System;
using System.Threading.Tasks;
using boilerplate.db;
using boilerplate.db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace boilerplate.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonRepository _personRepository;
        private ILogger<PersonController> _logger;

        public PersonController(
            PersonRepository personRepository,
            ILogger<PersonController> logger)
        {
            _personRepository = personRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Person> GetById(Guid id)
        {
            return await _personRepository.LoadPerson(id);
        }

        [HttpPost]
        public async Task Create(Person person)
        {
            await _personRepository.SavePerson(person);
        }
    }
}
