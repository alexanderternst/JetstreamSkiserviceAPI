using System.Text.Json.Serialization;

namespace JetstreamSkiserviceAPI.DTO
{
    /// <summary>
    /// DTO Klasse für User anmeldung
    /// </summary>
    public class AuthentificationDTO
    {
        [JsonPropertyName("user_username")]
        public string? Username { get; set; }

        [JsonPropertyName("user_password")]
        public string? Password { get; set; }
    }
}
