using EFCoreCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JetstreamServiceAPI.Models
{
    //public class Rootobject
    //{
    //    public Registration[] Property1 { get; set; }
    //}

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

        // Diese Methode braucht man schlussendlich nicht, dies ist nur zum kreieren der Datenbank
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ALEXANDERPC;Database=Registration;Trusted_Connection=True");
        }
    }
}
