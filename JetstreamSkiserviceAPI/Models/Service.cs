using System.ComponentModel.DataAnnotations;

namespace JetstreamSkiserviceAPI.Models
{
    public class Service
    {
        [Key]
        public int service_id { get; set; }

        public string service_name { get; set; }

        public List<Registration> registrations { get; set; }
    }
}
