using JetstreamSkiserviceAPI.DTO;
using JetstreamSkiserviceAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamSkiserviceAPI.Controllers
{
    /// <summary>
    /// Controller von abrufen von Registrationen nach Status
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private IStatusService _statusService;
        private readonly ILogger<StatusController> _logger;

        /// <summary>
        /// Konstruktor für instanziierung von Interface und Logger
        /// </summary>
        /// <param name="status">Interface Service</param>
        /// <param name="logger">Interface Logger</param>
        public StatusController(IStatusService status, ILogger<StatusController> logger)
        {
            _statusService = status;
            _logger = logger;
        }

        /// <summary>
        /// GetAll Methode welche Service aufruft
        /// </summary>
        /// <returns>Liste von StatusDTO</returns>
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

        /// <summary>
        /// GetByStatus Methode welche Service aufruft
        /// </summary>
        /// <param name="status">status</param>
        /// <returns>StatusDTO</returns>
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
