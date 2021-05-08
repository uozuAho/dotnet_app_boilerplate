using System.Collections.Generic;
using System.Threading.Tasks;
using boilerplate.db;
using boilerplate.db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace boilerplate.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly AnimalRepository _animalRepository;
        private ILogger<PersonController> _logger;

        public AnimalController(
            AnimalRepository animalRepository,
            ILogger<PersonController> logger)
        {
            _animalRepository = animalRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Animal>> GetAll()
        {
            return await _animalRepository.LoadAll();
        }
    }
}
