using Microsoft.EntityFrameworkCore;

namespace JetstreamSkiserviceAPI.Models
{
    /// <summary>
    /// Klasse für erstellen von Datenbanken
    /// </summary>
    public class RegistrationContext : DbContext
    {
        private readonly IConfiguration _config;

        /// <summary>
        /// Leerer Konstruktor
        /// </summary>
        public RegistrationContext()
        {
            
        }

        /// <summary>
        /// Konstruktor für instanziierung
        /// </summary>
        /// <param name="options"></param>
        /// <param name="config"></param>
        public RegistrationContext(DbContextOptions<RegistrationContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
        }

        public DbSet<Registration> Registrations { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<Priority> Priority { get; set; }

        public DbSet<Service> Service { get; set; }

        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string t = _config.GetConnectionString("RegistrationDB");
            optionsBuilder.UseSqlServer($@"{t}");
        }
    }
}
