using System.ComponentModel.DataAnnotations;

namespace JetstreamSkiserviceAPI.Models
{
    /// <summary>
    /// Status Klasse für Datenbankkreation/Datenbankverbindung
    /// </summary>
    public class Status
    {
        [Key]
        public int Status_id { get; set; }

        [StringLength(255)]
        public string? Status_name { get; set; }

        public List<Registration>? Registrations { get; set; }
    }
}