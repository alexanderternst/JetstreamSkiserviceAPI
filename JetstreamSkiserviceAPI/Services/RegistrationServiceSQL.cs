using JetstreamSkiserviceAPI;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using JetstreamSkiserviceAPI.Models;
using JetstreamSkiserviceAPI.DTO;

namespace JetstreamSkiserviceAPI.Services
{
    public class RegistrationServiceSQL : IRegistrationService
    {
        private readonly RegistrationContext _dbContext;

        public RegistrationServiceSQL(RegistrationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Registration> GetAll()
        {
            return _dbContext.Registrations.ToList();
        }

        public Registration? Get(int id)
        {
            return _dbContext.Registrations.Find(id);
        }

        public void Add(RegistrationDTO registration)
        {
            //var context = new RegistrationContext();

            Registration newRegistration = new Registration()
            {
                name = registration.name,
                email = registration.email,
                phone = registration.phone,
                priority = registration.priority,
                service = registration.service,
                create_date = registration.create_date,
                pickup_date = registration.pickup_date,
                Status = _dbContext.Status.FirstOrDefault(e => e.status_name == registration.status)
            };

            _dbContext.Add(newRegistration);
            _dbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var registration = _dbContext.Registrations.Find(Id);
            if (registration != null)
            {
                _dbContext.Registrations.Remove(registration);
                _dbContext.SaveChanges();
            }
        }

        public void Update(Registration registration)
        {
            _dbContext.Entry(registration).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}