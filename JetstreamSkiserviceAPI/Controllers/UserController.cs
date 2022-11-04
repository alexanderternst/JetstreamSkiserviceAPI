using JetstreamSkiserviceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamSkiserviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // POST für das einloggen
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            return null;
        }

        // GET für das Informationen einholen von Usern
    }
}
