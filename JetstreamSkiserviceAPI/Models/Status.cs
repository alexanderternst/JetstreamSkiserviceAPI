using System.ComponentModel.DataAnnotations;

namespace JetstreamSkiserviceAPI.Models
{
    public class Status
    {
        [Key]
        public int status_id { get; set; }

        [StringLength(255)]
        public string status_name { get; set; }

        public List<Registration> registrations { get; set; }
    }
}
