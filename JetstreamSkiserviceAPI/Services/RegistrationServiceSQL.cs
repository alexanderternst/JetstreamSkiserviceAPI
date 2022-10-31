using JetstreamSkiserviceAPI;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using JetstreamSkiserviceAPI.Models;

namespace JetstreamSkiserviceAPI.Services
{
    public class RegistrationServiceSQL : IRegistrationService
    {
        static List<Registration> registrations { get; set; } = new List<Registration>();
        static string Storage { get; set; }

        public RegistrationServiceSQL(IConfiguration config)
        {
            Storage = config["Storage"];

            var contextOptions = new DbContextOptionsBuilder<RegistrationContext>()
            .UseSqlServer($@"{Storage}")
            .Options;

            using (var context = new RegistrationContext(contextOptions))
            {
                registrations = context.Registrations.ToList();
            }

        }

        public List<Registration> GetAll() => registrations;

        public Registration? Get(int id) => registrations.FirstOrDefault(p => p.id == id);

        public void Add(Registration registration)
        {

            var contextOptions = new DbContextOptionsBuilder<RegistrationContext>()
            .UseSqlServer($@"{Storage}")
            .Options;

            using (var context = new RegistrationContext(contextOptions))
            {
                context.Add(registration);
                context.SaveChanges();

                registrations = context.Registrations.ToList();
            }
        }

        public void Delete(int Id)
        {
            var delete = new Registration { id = Id };

            var contextOptions = new DbContextOptionsBuilder<RegistrationContext>()
            .UseSqlServer($@"{Storage}")
            .Options;

            using (var context = new RegistrationContext(contextOptions))
            {
                context.Attach(delete);
                context.Remove(delete);
                context.SaveChanges();

                registrations = context.Registrations.ToList();
            }
        }

        public void Update(int Id, Registration registration)
        {
            var contextOptions = new DbContextOptionsBuilder<RegistrationContext>()
            .UseSqlServer($@"{Storage}")
            .Options;

            using (var context = new RegistrationContext(contextOptions))
            {
                var regi = context.Registrations.First(a => a.id == Id);

                //regi = registration;

                regi.name = registration.name;
                regi.email = registration.email;
                regi.phone = registration.phone;
                regi.priority = registration.priority;
                regi.service = registration.service;
                regi.create_date = registration.create_date;
                regi.pickup_date = registration.pickup_date;
                regi.status = registration.status;

                context.SaveChanges();
                
                registrations = context.Registrations.ToList();
            }
        }
    }
}