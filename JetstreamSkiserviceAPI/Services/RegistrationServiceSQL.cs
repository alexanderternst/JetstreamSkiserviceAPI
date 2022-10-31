using JetstreamSkiserviceAPI;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using JetstreamSkiserviceAPI.Models;

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

        public void Add(Registration registration)
        {
            _dbContext.Registrations.Add(registration);
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