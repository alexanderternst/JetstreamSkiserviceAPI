using JetstreamSkiserviceAPI.DTO;
using JetstreamSkiserviceAPI.Models;
using JetstreamSkiserviceAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamSkiserviceAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private IStatusService _statusService;
        private readonly ILogger<StatusController> _logger;

        public StatusController(IStatusService status, ILogger<StatusController> logger)
        {
            _statusService = status;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<StatusDTO>> GetAll()
        {
            try
            {
                return _statusService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound("Error occured");
            }
        }

        [HttpGet("{status}")]
        public ActionResult<StatusDTO> GetByStatus(string status)
        {
            try
            {
                return _statusService.GetStatus(status);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound("Error occured");
            }
        }
    }
}
