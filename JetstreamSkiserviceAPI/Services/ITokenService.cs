using JetstreamSkiserviceAPI.Models;

namespace JWTAuthentication.Services
{
	public interface ITokenService
	{
		string CreateToken(string username);

		List<Users> Login();

    }
}
