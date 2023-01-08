using System.ComponentModel.DataAnnotations;

namespace JetstreamSkiserviceAPI.Models
{
    /// <summary>
    /// Registration Klasse für Datenbankkreation/Datenbankverbindung
    /// </summary>
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }

        [StringLength(255)]
        public string? Email { get; set; }

        [StringLength(255)]
        public string? Phone { get; set; }

        public DateTime Create_date { get; set; }

        public DateTime Pickup_date { get; set; }

        [StringLength(255)]
        public string? Comment { get; set; }

        public Status? Status { get; set; }
        public Priority? Priority { get; set; }
        public Service? Service { get; set; }
    }
}
