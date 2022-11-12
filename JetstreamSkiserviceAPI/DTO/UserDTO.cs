using System.Text.Json.Serialization;

namespace JetstreamSkiserviceAPI.DTO
{
    /// <summary>
    /// DTO Klasse für User anmeldung
    /// </summary>
    public class UserDTO
    {
        [JsonPropertyName("user_username")]
        public string username { get; set; }

        [JsonPropertyName("user_password")]
        public string password { get; set; }

    }
}
