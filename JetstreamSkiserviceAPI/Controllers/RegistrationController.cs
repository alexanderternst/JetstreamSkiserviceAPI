using EFCoreCodeFirst.Models;
using JetstreamServiceAPI.Models;
using JetstreamServiceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JetstreamServiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(ILogger<RegistrationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Registration>> GetAll() =>
        RegistrationService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Registration> Get(int id)
        {
            _logger.LogError("This is an error.");
            var registration = RegistrationService.Get(id);

            if (registration == null)
                return NotFound();

            return registration;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Registration registration)
        {
            RegistrationService.Add(registration);

            // fix this
            return CreatedAtAction(nameof(Create), new { id = registration.id }, registration);
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var registration = RegistrationService.Get(id);

            if (registration is null)
                return NotFound();

            RegistrationService.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Registration registration)
        {
            if (id != registration.id)
                registration.id = id;

            var existingRegi = RegistrationService.Get(id);
            if (existingRegi is null)
                return NotFound();

            RegistrationService.Update(id, registration);

            return NoContent();
        }
    }
}
