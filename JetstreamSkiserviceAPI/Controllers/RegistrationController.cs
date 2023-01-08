using JetstreamSkiserviceAPI.DTO;
using JetstreamSkiserviceAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamSkiserviceAPI.Controllers
{
    /// <summary>
    /// Controller für Registrationen
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private IRegistrationService _registrationService;
        private readonly ILogger<RegistrationController> _logger;

        /// <summary>
        /// Konstruktor für instanziierung von Interface und Logger
        /// </summary>
        /// <param name="registration">Interface Service</param>
        /// <param name="logger">Interface Logger</param>
        public RegistrationController(IRegistrationService registration, ILogger<RegistrationController> logger)
        {
            _registrationService = registration;
            _logger = logger;
        }

        /// <summary>
        /// GetAll Methode welche Service über Interface aufruft
        /// </summary>
        /// <returns>List von RegistrationDTO</returns>
        [HttpGet]
        public ActionResult<List<RegistrationDTO>> GetAll()
        {
            try
            {
                return _registrationService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured, {ex.Message}");
            }
        }


        /// <summary>
        /// GetById Methode welche Service über Interface aufruft
        /// </summary>
        /// <param name="id"></param>
        /// <returns>RegistrationDTO Objekt</returns>
        [HttpGet("{id}")]
        public ActionResult<RegistrationDTO> Get(int id)
        {
            try
            {
                RegistrationDTO reg = _registrationService.Get(id);
                if (reg == null)
                    return NotFound();
                return reg;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured, {ex.Message}");
            }
        }

        /// <summary>
        /// Post Methode welche Service über Interface aufruft
        /// </summary>
        /// <param name="registration"></param>
        /// <returns>RegistrationDTO</returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create(RegistrationDTO registration)
        {
            try
            {
                _registrationService.Add(registration);
                return CreatedAtAction(nameof(Create), new { id = registration.Id }, registration);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured, {ex.Message}");
            }
        }

        /// <summary>
        /// Delete Methode welche Service über Interface aufruft
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult</returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var registration = _registrationService.Get(id);
                if (registration == null)
                    return NotFound();
                _registrationService.Delete(id);
                return Content($"Item in row {id} deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured, {ex.Message}");
            }
        }

        /// <summary>
        /// Update Methode welche Service über Interface aufruft
        /// </summary>
        /// <param name="id"></param>
        /// <param name="registration"></param>
        /// <returns>ActionResult</returns>
        [HttpPut("{id}")]
        public ActionResult Update(int id, RegistrationDTO registration)
        {
            try
            {
                RegistrationDTO reg = _registrationService.Get(id);
                if (reg == null)
                    return NotFound();

                reg.Name = registration.Name;
                reg.Email = registration.Email;
                reg.Phone = registration.Phone;
                reg.CreateDate = registration.CreateDate;
                reg.PickupDate = registration.PickupDate;

                reg.Status = registration.Status;
                reg.Service = registration.Service;
                reg.Priority = registration.Priority;
                reg.Comment = registration.Comment;

                _registrationService.Update(reg);

                return CreatedAtAction(nameof(Create), new { id = id }, registration);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured, {ex.Message}");
            }
        }
    }
}