using System.ComponentModel.DataAnnotations;

namespace JetstreamSkiserviceAPI.Models
{
    public class Service
    {
        [Key]
        public int service_id { get; set; }

        [StringLength(255)]
        public string service_name { get; set; }

        public List<Registration> registrations { get; set; }
    }
}
