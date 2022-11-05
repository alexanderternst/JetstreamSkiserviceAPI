using JetstreamSkiserviceAPI.DTO;
using JetstreamSkiserviceAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthentication.Services
{
	public class TokenService : ITokenService
	{
        private readonly RegistrationContext _dbContext;
        //Injecting IConfiguration into this class in order to read Token Key from the configuration file
        private readonly SymmetricSecurityKey _key;
		public TokenService(IConfiguration config, RegistrationContext dbContext)
		{
			_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            _dbContext = dbContext;
        }

		public string CreateToken(string username)
		{
			//Creating Claims. You can add more information in these claims. For example email id.
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.NameId, username)
			};

			//Creating credentials. Specifying which type of Security Algorithm we are using
			var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

			//Creating Token description
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddMinutes(1),
				SigningCredentials = creds
			};

			var tokenHandler = new JwtSecurityTokenHandler();

			var token = tokenHandler.CreateToken(tokenDescriptor);

			//Finally returning the created token
			return tokenHandler.WriteToken(token);
		}

		public List<Users> Login()
		{
			List<Users> users = new List<Users>();
			users = _dbContext.Users.ToList();
			return users;
		}
	}
}
