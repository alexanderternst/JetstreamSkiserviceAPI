using JetstreamSkiserviceAPI.Models;

namespace JetstreamSkiserviceAPI.DTO
{
    public class StatusDTO
    {
        public int status_id { get; set; }
        public string status_name { get; set; }
        public List<RegistrationDTO> registration { get; set; } = new List<RegistrationDTO>();
    }
}
