using JetstreamSkiserviceAPI.DTO;
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
        public IEnumerable<RegistrationDTO> GetAll()
        {
            List<Registration> registrations = _registrationService.GetAll().ToList();

            // Zum kunden werden DTO Objekte gegeben
            List<RegistrationDTO> result = new List<RegistrationDTO>();
            registrations.ForEach(e => result.Add(new RegistrationDTO()
            {
                id = e.id,
                name = e.name,
                email = e.email,
                phone = e.phone,
                priority = e.priority,
                service = e.service,
                create_date = e.create_date,
                pickup_date = e.pickup_date,
                status = e.Status.status_name
                //status = e.status
            }));

            return result;
        }

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<RegistrationDTO> Get(int id)
        {
            Registration e = _registrationService.Get(id);
            if (e == null)
                return NotFound();

            return new RegistrationDTO()
            {
                id = e.id,
                name = e.name,
                email = e.email,
                phone = e.phone,
                priority = e.priority,
                service = e.service,
                create_date = e.create_date,
                pickup_date = e.pickup_date,
                //status = e.status
            };
        }

        // POST action
        [HttpPost]
        public ActionResult<Registration> Create(RegistrationDTO registrationDTO)
        {
            //var context = new RegistrationContext();

            //Registration newRegistration = new Registration()
            //{
            //    name = registrationDTO.name,
            //    email = registrationDTO.email,
            //    phone = registrationDTO.phone,
            //    priority = registrationDTO.priority,
            //    service = registrationDTO.service,
            //    create_date = registrationDTO.create_date,
            //    pickup_date = registrationDTO.pickup_date,
            //    //status = registrationDTO.status
            //};

            //newRegistration.Status = context.Status.FirstOrDefault(e => e.status_name == registrationDTO.status);

            _registrationService.Add(registrationDTO);

            //return CreatedAtAction(nameof(Create), new { id = newRegistration.id }, newRegistration);
            return null;
        }

        // DELETE action
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _registrationService.Delete(id);
        }

        // PUT action
        [HttpPut("{id}")]
        public ActionResult Update(int id, Registration registration)
        {
            //if (id != registration.id)
            //    registration.id = id;

            Registration e = _registrationService.Get(id);
            if (e == null)
                return BadRequest();

            e.name = registration.name;
            e.email = registration.email;
            e.phone = registration.phone;
            e.priority = registration.priority;
            e.service = registration.service;
            e.create_date = registration.create_date;
            e.pickup_date = registration.pickup_date;
            //e.status = registration.status;

            _registrationService.Update(e);

            return NoContent();
        }
    }
}
