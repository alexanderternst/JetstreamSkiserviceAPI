﻿using JetstreamSkiserviceAPI.DTO;
using JetstreamSkiserviceAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Immutable;
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
            _dbContext = dbContext;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        }

		public string CreateToken(string username)
		{
			try
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
					Expires = DateTime.Now.AddDays(1),
					SigningCredentials = creds
				};

				var tokenHandler = new JwtSecurityTokenHandler();

				var token = tokenHandler.CreateToken(tokenDescriptor);

				//Finally returning the created token
				return tokenHandler.WriteToken(token);
			}
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public List<Users> Login()
		{
			try
			{
				List<Users> users = new List<Users>();
				users = _dbContext.Users.ToList();
				return users;
			}
			catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
		}

		public void Counter(int userid)
		{
			try
			{
				Users u = new Users();
				u = _dbContext.Users.Where(u => u.user_id == userid).FirstOrDefault();
				u.counter = u.counter + 1;
				_dbContext.Entry(u).State = EntityState.Modified;
				_dbContext.SaveChanges();
			}
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public void Unban(int userid)
		{
			try
			{
				Users u = new Users();
				u = _dbContext.Users.Where(u => u.user_id == userid).FirstOrDefault();
				u.counter = 0;
				_dbContext.Entry(u).State = EntityState.Modified;
				_dbContext.SaveChanges();
			}
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public List<Users> GetUsers()
		{
			try
			{
				List<Users> users = _dbContext.Users.ToList();
				List<Users> result = new List<Users>();
				users.ForEach(e => result.Add(new Users()
				{
					user_id = e.user_id,
					username = e.username,
					password = "hidden",
					counter = e.counter
				}));
				return result;
			}
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
	}
}
