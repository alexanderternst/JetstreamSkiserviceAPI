using JetstreamSkiserviceAPI.DTO;
using JetstreamSkiserviceAPI.Models;
using JetstreamSkiserviceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamSkiserviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private IStatusService _statusService;
        private readonly ILogger<RegistrationController> _logger;

        public StatusController(IStatusService status, ILogger<RegistrationController> logger)
        {
            _statusService = status;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<StatusDTO>> GetAll() => _statusService.GetAll();

        [HttpGet("{status}")]
        public ActionResult<StatusDTO> GetByStatus(string status) => _statusService.GetStatus(status);
    }
}
