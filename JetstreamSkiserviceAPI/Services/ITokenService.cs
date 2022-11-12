using JetstreamSkiserviceAPI.Models;

namespace JWTAuthentication.Services
{
	/// <summary>
	/// Interface für TokenService
	/// </summary>
	public interface ITokenService
	{
		string CreateToken(string username);

		List<Users> Login();

		void Counter(int userid);

		void Unban(int userid);

		List<Users> GetUsers();

    }
}
