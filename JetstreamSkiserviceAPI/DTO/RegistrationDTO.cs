using System.Text.Json.Serialization;

namespace JetstreamSkiserviceAPI.DTO
{
    /// <summary>
    /// DTO Klasse für Registrationen
    /// </summary>
    public class RegistrationDTO
    {
        [JsonPropertyName("registration_id")]
        public int? Id { get; set; }

        [JsonPropertyName("registration_name")]
        public string? Name { get; set; }

        [JsonPropertyName("registration_email")]
        public string? Email { get; set; }

        [JsonPropertyName("registration_phone")]
        public string? Phone { get; set; }

        [JsonPropertyName("registration_create_date")]
        public DateTime CreateDate { get; set; }

        [JsonPropertyName("registration_pickup_date")]
        public DateTime PickupDate { get; set; }

        [JsonPropertyName("registration_status")]
        public string? Status { get; set; }

        [JsonPropertyName("registration_priority")]
        public string? Priority { get; set; }

        [JsonPropertyName("registration_service")]
        public string? Service { get; set; }

        [JsonPropertyName("registration_comment")]
        public string? Comment { get; set; }
    }
}
