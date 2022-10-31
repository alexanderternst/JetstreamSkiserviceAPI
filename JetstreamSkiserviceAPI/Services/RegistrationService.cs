using JetstreamServiceAPI.Models;
using System.Text.Json;
using Newtonsoft.Json;
using EFCoreCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace JetstreamServiceAPI.Services
{
    public class RegistrationService
    {
        static List<Registration> registrations { get; set; } = new List<Registration>();

        static RegistrationService()
        {
            var contextOptions = new DbContextOptionsBuilder<RegistrationContext>()
            .UseSqlServer(@"Server=ALEXANDERPC;Database=Registration;Trusted_Connection=True")
            .Options;

            using (var context = new RegistrationContext(contextOptions))
            {
                registrations = context.Registrations.ToList();
            }

        }

        public static List<Registration> GetAll() => registrations;

        public static Registration? Get(int id) => registrations.FirstOrDefault(p => p.id == id);

        public static void Add(Registration registration)
        {

            var contextOptions = new DbContextOptionsBuilder<RegistrationContext>()
            .UseSqlServer(@"Server=ALEXANDERPC;Database=Registration;Trusted_Connection=True")
            .Options;

            using (var context = new RegistrationContext(contextOptions))
            {
                context.Add(registration);
                context.SaveChanges();

                registrations = context.Registrations.ToList();
            }
        }

        public static void Delete(int Id)
        {
            var delete = new Registration { id = Id };

            var contextOptions = new DbContextOptionsBuilder<RegistrationContext>()
            .UseSqlServer(@"Server=ALEXANDERPC;Database=Registration;Trusted_Connection=True")
            .Options;

            using (var context = new RegistrationContext(contextOptions))
            {
                context.Attach(delete);
                context.Remove(delete);
                context.SaveChanges();

                registrations = context.Registrations.ToList();
            }
        }

        public static void Update(int Id,Registration registration)
        {
            var contextOptions = new DbContextOptionsBuilder<RegistrationContext>()
            .UseSqlServer(@"Server=ALEXANDERPC;Database=Registration;Trusted_Connection=True")
            .Options;

            using (var context = new RegistrationContext(contextOptions))
            {
                var regi = context.Registrations.First(a => a.id == Id);
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
