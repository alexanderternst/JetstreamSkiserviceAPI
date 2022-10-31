using System.ComponentModel.DataAnnotations;

namespace JetstreamSkiserviceAPI.Models
{
    public class Registration
    {
        [Key]
        public int id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        public int phone { get; set; }

        [StringLength(255)]
        public string priority { get; set; }

        [StringLength(255)]
        public string service { get; set; }

        public DateTime create_date { get; set; }

        public DateTime pickup_date { get; set; }

        [StringLength(255)]
        public string status { get; set; }
    }
}
