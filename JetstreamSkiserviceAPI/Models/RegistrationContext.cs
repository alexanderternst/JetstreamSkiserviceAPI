using Microsoft.EntityFrameworkCore;

namespace JetstreamSkiserviceAPI.Models
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext()
        {
            
        }

        public RegistrationContext(DbContextOptions<RegistrationContext> options)
            : base(options)
        {

        }

        public DbSet<Registration> Registrations { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<Priority> Priority { get; set; }

        public DbSet<Service> Service { get; set; }

        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ALEXANDERPC;Database=Registration;Trusted_Connection=True");
        }
    }
}
