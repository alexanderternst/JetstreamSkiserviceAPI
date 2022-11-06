using JetstreamSkiserviceAPI.DTO;
using JetstreamSkiserviceAPI.Models;
using JWTAuthentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamSkiserviceAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
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

        [HttpPost("login")]
        public ActionResult Login([FromBody] UserDTO user)
        {
            try
            {
                Users = _tokenService.Login();

                foreach (Users use in Users)
                {
                    if (user.username == use.username && user.password == use.password)
                        return new JsonResult(new { userName = user.username, token = _tokenService.CreateToken(user.username) });
                    else
                        return Unauthorized("Invalid Credentials");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured, {ex.Message}");
            }
        }
    }
}
