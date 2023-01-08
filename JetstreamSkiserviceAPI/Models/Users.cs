using System.ComponentModel.DataAnnotations;

namespace JetstreamSkiserviceAPI.Models
{
    /// <summary>
    /// User Klasse für Datenbankkreation/Datenbankverbindung
    /// </summary>
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string? Username { get; set; }

        [StringLength(255)]
        public string? Password { get; set; }

        public int? Counter { get; set; }
    }
}
