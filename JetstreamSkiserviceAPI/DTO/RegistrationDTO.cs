using System.Text.Json.Serialization;

namespace JetstreamSkiserviceAPI.DTO
{
    public class RegistrationDTO
    {
        [JsonPropertyName("registration_id")]
        public int id { get; set; }

        [JsonPropertyName("registration_name")]
        public string name { get; set; }

        [JsonPropertyName("registration_email")]
        public string email { get; set; }

        [JsonPropertyName("registration_phone")]
        public string phone { get; set; }

        [JsonPropertyName("registration_create_date")]
        public DateTime create_date { get; set; }

        [JsonPropertyName("registration_pickup_date")]
        public DateTime pickup_date { get; set; }

        [JsonPropertyName("registration_status")]
        public string status { get; set; }

        [JsonPropertyName("registration_priority")]
        public string priority { get; set; }

        [JsonPropertyName("registration_service")]
        public string service { get; set; }

        [JsonPropertyName("registration_comment")]
        public string comment { get; set; }
    }
}
