using JetstreamSkiserviceAPI.DTO;
using JetstreamSkiserviceAPI.Models;
using JWTAuthentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamSkiserviceAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public List<Users> Users { get; set; } = new List<Users>();
        private readonly ITokenService _tokenService;
        private readonly ILogger<UserController> _logger;
        public UserController(ITokenService tokenService, ILogger<UserController> logger)
        {
            _tokenService = tokenService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] UserDTO user)
        {
            try
            {
                Users = _tokenService.Login();

                foreach (Users use in Users)
                {
                    if (use.counter >= 3)
                    {
                        return Unauthorized("This user seems to have been banned. Please contact our support team.");
                    }
                    else if (user.username == use.username && user.password == use.password)
                    {
                        return new JsonResult(new { userName = user.username, token = _tokenService.CreateToken(user.username) });
                    }
                    else if (user.username == use.username && user.password != use.password)
                    {
                        _tokenService.Counter(use.user_id);
                        return Unauthorized($"Invalid Credentials. {3 - use.counter} attepts left");
                    }
                    else
                    {
                        return Unauthorized("This user does not exits, try again.");
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

        [HttpGet]
        public ActionResult<List<Users>> GetAll()
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
