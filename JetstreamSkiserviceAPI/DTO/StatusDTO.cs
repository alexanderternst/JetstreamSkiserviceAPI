using System.Text.Json.Serialization;

namespace JetstreamSkiserviceAPI.DTO
{
    /// <summary>
    /// DTO Klasse für Stati
    /// </summary>
    public class StatusDTO
    {
        [JsonPropertyName("status_id")]
        public int? StatusId { get; set; }
        [JsonPropertyName("status_name")]
        public string? StatusName { get; set; }
        [JsonPropertyName("status_registrations")]
        public List<RegistrationDTO> Registrations { get; set; } = new List<RegistrationDTO>();
    }
}
