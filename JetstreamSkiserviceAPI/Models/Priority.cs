using System.ComponentModel.DataAnnotations;

namespace JetstreamSkiserviceAPI.Models
{
    /// <summary>
    /// Priority Klasse für Datenbankkreation/Datenbankverbindung
    /// </summary>
    public class Priority
    {
        [Key]
        public int priority_id { get; set; }

        [StringLength(255)]
        public string priority_name { get; set; }

        public List<Registration> registrations { get; set; }
    }
}
