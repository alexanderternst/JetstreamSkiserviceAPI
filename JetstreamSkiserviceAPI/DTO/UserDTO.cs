using System.Text.Json.Serialization;

namespace JetstreamSkiserviceAPI.DTO
{
    /// <summary>
    /// DTO Klasse für User anmeldung
    /// </summary>
    public class UserDTO
    {
        [JsonPropertyName("user_id")]
        public int? Id { get; set; }

        [JsonPropertyName("user_username")]
        public string? Username { get; set; }

        [JsonPropertyName("user_password")]
        public string? Password { get; set; }

        [JsonPropertyName("user_counter")]
        public int? Counter { get; set; }

    }
}
