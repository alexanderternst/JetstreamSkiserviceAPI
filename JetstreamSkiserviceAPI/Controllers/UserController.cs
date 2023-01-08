using JetstreamSkiserviceAPI.DTO;
using JetstreamSkiserviceAPI.Models;
using JWTAuthentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamSkiserviceAPI.Controllers
{
    /// <summary>
    /// Controller für JWT Key/Login
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public List<Users> Users { get; set; } = new List<Users>();
        private readonly ITokenService _tokenService;
        private readonly ILogger<UserController> _logger;

        /// <summary>
        /// Konstruktor für instanziierung von Interface und Logger
        /// </summary>
        /// <param name="tokenService">Interface Service</param>
        /// <param name="logger">Interface Logger</param>
        public UserController(ITokenService tokenService, ILogger<UserController> logger)
        {
            _tokenService = tokenService;
            _logger = logger;
        }

        /// <summary>
        /// Login Methode welche User über Interfce/Service abruft und dann eine validierung durchführt.
        /// Je nach validierung wird JWT Key returned.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>ActionResult</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] UserDTO user)
        {
            try
            {
                Users = _tokenService.Login();

                foreach (Users use in Users)
                {
                    if (user.username == use.username && user.password == use.password)
                    {
                        if (use.counter >= 3)
                        {
                            return Unauthorized("This user seems to have been banned. Please contact our support team.");
                        }
                        else
                        {
                            return new JsonResult(new { user_username = user.username, token = _tokenService.CreateToken(user.username) });
                        }
                    }
                    else if (user.username == use.username && user.password != use.password)
                    {
                        if (use.counter >= 3)
                        {
                            return Unauthorized("This user seems to have been banned. Please contact our support team.");
                        }
                        else
                        {
                            _tokenService.Counter(use.user_id);
                            return Unauthorized($"Invalid Credentials. {3 - use.counter} attepts left");
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured, {ex.Message}");
            }
        }

        /// <summary>
        /// Unban Methode welche User über Interface/Service entbannt
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult</returns>
        [HttpPut("unban/{id}")]
        public ActionResult Unban(int id)
        {
            try
            {
                _tokenService.Unban(id);
                return Content($"User with id {id} unbanned.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured, {ex.Message}");
            }
        }

        /// <summary>
        /// GetAll Methode welche alle User über Interface/Service abruft
        /// </summary>
        /// <returns>Liste von Usern</returns>

        [HttpGet]
        public ActionResult<List<AuthDTO>> GetAll()
        {
            try
            {
                return _tokenService.GetUsers();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured, {ex.Message}");
            }
        }
    }
}
