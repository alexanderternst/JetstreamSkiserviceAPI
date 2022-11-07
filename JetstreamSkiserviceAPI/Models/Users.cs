using System.ComponentModel.DataAnnotations;

namespace JetstreamSkiserviceAPI.Models
{
    public class Users
    {
        [Key]
        public int user_id { get; set; }

        [StringLength(255)]
        public string username { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string Key { get; set; }

        [StringLength(255)]
        public string Issuer { get; set; }

        [StringLength(255)]
        public string Audience { get; set; }
    }
}
