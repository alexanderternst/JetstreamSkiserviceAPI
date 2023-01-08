using System.ComponentModel.DataAnnotations;

namespace JetstreamSkiserviceAPI.Models
{
    /// <summary>
    /// Priority Klasse für Datenbankkreation/Datenbankverbindung
    /// </summary>
    public class Priority
    {
        [Key]
        public int Priority_id { get; set; }

        [StringLength(255)]
        public string? Priority_name { get; set; }

        public List<Registration>? Registrations { get; set; }
    }
}
