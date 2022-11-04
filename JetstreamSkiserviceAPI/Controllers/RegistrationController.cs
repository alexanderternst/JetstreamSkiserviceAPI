using JetstreamSkiserviceAPI.DTO;
using JetstreamSkiserviceAPI.Models;
using JetstreamSkiserviceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamSkiserviceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public ActionResult<List<RegistrationDTO>> GetAll() => _registrationService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<RegistrationDTO> Get(int id)
        {
            RegistrationDTO e = _registrationService.Get(id);
            if (e == null)
                return NotFound();
            return e;

        }

        // POST action
        [HttpPost]
        public ActionResult<Registration> Create(RegistrationDTO registrationDTO)
        {
            _registrationService.Add(registrationDTO);

            return CreatedAtAction(nameof(Create), new { id = registrationDTO.id }, registrationDTO);
        }

        // DELETE action
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var registration = _registrationService.Get(id);
            if (registration == null)
                return NotFound();
            _registrationService.Delete(id);
            return NoContent();
        }

        // PUT action
        [HttpPut("{id}")]
        public ActionResult Update(int id, RegistrationDTO registration)
        {
            RegistrationDTO e = _registrationService.Get(id);
            if (e == null)
                return NotFound();

            e.name = registration.name;
            e.email = registration.email;
            e.phone = registration.phone;
            e.create_date = registration.create_date;
            e.pickup_date = registration.pickup_date;
            
            e.status = registration.status;
            e.service = registration.service;
            e.priority = registration.priority;

            _registrationService.Update(e);

            return NoContent();
        }
    }
}
