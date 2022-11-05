﻿using JetstreamSkiserviceAPI.DTO;
using JetstreamSkiserviceAPI.Models;
using JWTAuthentication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamSkiserviceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public List<Users> Users { get; set; } = new List<Users>();
        private readonly ITokenService _tokenService;
        public UserController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDTO user)
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
    }
}
