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
                foreach (var registration in context.Registrations)
                {
                    registrations.Add(new Registration(registration.id,
                                           registration.name,
                                           registration.email,
                                           registration.phone,
                                           registration.priority,
                                           registration.service,
                                           registration.create_date,
                                           registration.pickup_date,
                                           registration.status));

                }
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
                var regi = new Registration
                {
                    name = registration.name,
                    email = registration.email,
                    phone = registration.phone,
                    priority = registration.priority,
                    service = registration.service,
                    create_date = registration.create_date,
                    pickup_date = registration.pickup_date,
                    status = registration.status

                };
                context.Add(regi);
                context.SaveChanges();

                foreach (var regi2 in context.Registrations)
                {
                    registrations.Add(new Registration(regi2.id,
                                           regi2.name,
                                           regi2.email,
                                           regi2.phone,
                                           regi2.priority,
                                           regi2.service,
                                           regi2.create_date,
                                           regi2.pickup_date,
                                           regi2.status));

                }
            }
        }
    }
}
