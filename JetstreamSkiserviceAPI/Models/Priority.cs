using System.ComponentModel.DataAnnotations;

namespace JetstreamSkiserviceAPI.Models
{
    public class Priority
    {
        [Key]
        public int priority_id { get; set; }

        public string priority_name { get; set; }

        public List<Registration> registrations { get; set; }
    }
}
