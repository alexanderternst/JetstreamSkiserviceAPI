using System.Text.Json.Serialization;

namespace JetstreamSkiserviceAPI.DTO
{
    public class UserDTO
    {
        [JsonPropertyName("user_username")]
        public string username { get; set; }

        [JsonPropertyName("user_password")]
        public string password { get; set; }

    }
}
