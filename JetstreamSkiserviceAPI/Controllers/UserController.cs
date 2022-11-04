using JetstreamSkiserviceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamSkiserviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // TODO
        // POST für das einloggen
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            // Siehe JWTAuth Aufgabe
            // Methode welche richtigen User Daten zurückgibt
            // Vergleich ob Daten stimmen


            return null;
        }

        // TODO
        // GET für das Informationen einholen von Usern
    }
}
