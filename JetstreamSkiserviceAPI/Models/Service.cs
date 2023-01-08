using System.ComponentModel.DataAnnotations;

namespace JetstreamSkiserviceAPI.Models
{
    /// <summary>
    /// Service Klasse für Datenbankkreation/Datenbankverbindung
    /// </summary>
    public class Service
    {
        [Key]
        public int Service_id { get; set; }

        [StringLength(255)]
        public string? Service_name { get; set; }

        public List<Registration>? Registrations { get; set; }
    }
}
