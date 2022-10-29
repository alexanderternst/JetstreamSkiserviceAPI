﻿using JetstreamServiceAPI.Models;
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

    }
}
