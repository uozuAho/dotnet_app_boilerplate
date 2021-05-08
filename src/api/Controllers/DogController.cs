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
    public class DogController : ControllerBase
    {
        private readonly DogRepository _dogRepository;
        private ILogger<PersonController> _logger;

        public DogController(
            DogRepository dogRepository,
            ILogger<PersonController> logger)
        {
            _dogRepository = dogRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Dog> GetById(Guid id)
        {
            return await _dogRepository.Load(id);
        }

        [HttpPost]
        public async Task Create(Dog person)
        {
            await _dogRepository.Save(person);
        }
    }
}
