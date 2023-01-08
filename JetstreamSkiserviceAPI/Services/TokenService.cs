using JetstreamSkiserviceAPI.DTO;
using JetstreamSkiserviceAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthentication.Services
{
	/// <summary>
	/// Token Service (User) für erstellen von JWT Token/abrufen von Usern
	/// </summary>
	public class TokenService : ITokenService
	{
        private readonly RegistrationContext _dbContext;
        private readonly SymmetricSecurityKey _key;

		/// <summary>
		/// Konstruktor für instanziierung von SQL Server vebindung/Konfiguration (appsettings file)
		/// </summary>
		/// <param name="config"></param>
		/// <param name="dbContext"></param>
		public TokenService(IConfiguration config, RegistrationContext dbContext)
		{
            _dbContext = dbContext;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        }

		/// <summary>
		/// Methode CreateToken für kreieren von JWT Token
		/// Hier setzen wir die gültigkeitsdauer des JWT Token auf einen Tag
		/// </summary>
		/// <param name="username">username</param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
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

		/// <summary>
		/// Methode Login für abrufen von Usern
		/// </summary>
		/// <returns>Liste von Usern</returns>
		/// <exception cref="Exception"></exception>
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

		/// <summary>
		/// Methode Counter um den counter eines Users +1 zu setzen
		/// </summary>
		/// <param name="userid"></param>
		/// <exception cref="Exception"></exception>
		public void Counter(int userid)
		{
			try
			{
				Users user = new Users();
                user = _dbContext.Users.Where(u => u.Id == userid).FirstOrDefault();
                user.Counter = user.Counter + 1;
				_dbContext.Entry(user).State = EntityState.Modified;
				_dbContext.SaveChanges();
			}
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		/// <summary>
		/// Methode unban welchen User auf 0 setzt (Counter auf 0 setzen)
		/// </summary>
		/// <param name="userid"></param>
		/// <exception cref="Exception"></exception>
		public void Unban(int userid)
		{
			try
			{
				Users user = new Users();
                user = _dbContext.Users.Where(u => u.Id == userid).FirstOrDefault();
                user.Counter = 0;
				_dbContext.Entry(user).State = EntityState.Modified;
				_dbContext.SaveChanges();
			}
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		/// <summary>
		/// Methode GetUsers für das abrufen von allen Usern
		/// </summary>
		/// <returns>Liste von Usern</returns>
		/// <exception cref="Exception"></exception>
		public List<UserDTO> GetUsers()
		{
			try
			{
				List<Users> users = _dbContext.Users.ToList();
				List<UserDTO> result = new List<UserDTO>();
				users.ForEach(e => result.Add(new UserDTO()
				{
					Id = e.Id,
					Username = e.Username,
					Password = null,
					Counter = e.Counter
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
