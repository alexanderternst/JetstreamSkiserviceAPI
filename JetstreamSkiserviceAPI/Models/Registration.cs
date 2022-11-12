using System.ComponentModel.DataAnnotations;

namespace JetstreamSkiserviceAPI.Models
{
    /// <summary>
    /// Registration Klasse für Datenbankkreation/Datenbankverbindung
    /// </summary>
    public class Registration
    {
        [Key]
        public int id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string phone { get; set; }

        public DateTime create_date { get; set; }

        public DateTime pickup_date { get; set; }

        [StringLength(255)]
        public string comment { get; set; }

        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public Service Service { get; set; }
    }
}
