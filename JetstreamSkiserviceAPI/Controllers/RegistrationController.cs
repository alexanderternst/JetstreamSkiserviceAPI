using JetstreamSkiserviceAPI.Models;
using JetstreamSkiserviceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamSkiserviceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private IRegistrationService _registrationService;
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(IRegistrationService registration, ILogger<RegistrationController> logger)
        {
            _registrationService = registration;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Registration>> GetAll() =>
        _registrationService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Registration> Get(int id)
        {
            _logger.LogError("This is an error.");
            var registration = _registrationService.Get(id);

            if (registration == null)
                return NotFound();

            return registration;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Registration registration)
        {
            _registrationService.Add(registration);
            return CreatedAtAction(nameof(Create), new { id = registration.id }, registration);
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var registration = _registrationService.Get(id);

            if (registration is null)
                return NotFound();

            _registrationService.Delete(id);

            return NoContent();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Registration registration)
        {
            //if (id != registration.id)
            //    return BadRequest();
            if (id != registration.id)
                registration.id = id;

            var existingPizza = _registrationService.Get(id);
            if (existingPizza is null)
                return NotFound();

            _registrationService.Update(id, registration);

            return NoContent();
        }
    }
}
