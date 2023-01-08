using System.Text.Json.Serialization;

namespace JetstreamSkiserviceAPI.DTO
{
    /// <summary>
    /// DTO Klasse für User anmeldung
    /// </summary>
    public class AuthDTO
    {
        [JsonPropertyName("user_id")]
        public int id { get; set; }

        [JsonPropertyName("user_username")]
        public string username { get; set; }

        [JsonPropertyName("user_password")]
        public string password { get; set; }

        [JsonPropertyName("user_counter")]
        public int counter { get; set; }

    }
}
