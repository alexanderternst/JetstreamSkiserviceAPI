using JetstreamSkiserviceAPI;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using JetstreamSkiserviceAPI.Models;
using JetstreamSkiserviceAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace JetstreamSkiserviceAPI.Services
{
    public class RegistrationServiceSQL : IRegistrationService
    {
        private readonly RegistrationContext _dbContext;

        public List<Registration> registrations = new List<Registration>();

        public RegistrationServiceSQL(RegistrationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<RegistrationDTO> GetAll()
        {
            registrations = _dbContext.Registrations.Include("Status").Include("Priority").Include("Service").ToList();

            List<RegistrationDTO> result = new List<RegistrationDTO>();
            registrations.ForEach(e => result.Add(new RegistrationDTO()
            {
                id = e.id,
                name = e.name,
                email = e.email,
                phone = e.phone,
                create_date = e.create_date,
                pickup_date = e.pickup_date,
                status = e.Status.status_name,
                priority = e.Priority.priority_name,
                service = e.Service.service_name
            }));

            return result;
        }

        public RegistrationDTO? Get(int id)
        {
            List<RegistrationDTO> t = GetAll();

            RegistrationDTO r = t.Find(p => p.id == id);

            return new RegistrationDTO()
            {
                id = r.id,
                name = r.name,
                phone = r.phone,
                email = r.email,
                create_date = r.create_date,
                pickup_date = r.pickup_date,
                service = r.service,
                priority = r.priority,
                status = r.status
            };
        }

        public void Add(RegistrationDTO registration)
        {
            Registration newRegistration = new Registration()
            {
                name = registration.name,
                email = registration.email,
                phone = registration.phone,
                create_date = registration.create_date,
                pickup_date = registration.pickup_date,
                Status = _dbContext.Status.FirstOrDefault(e => e.status_name == registration.status),
                Priority = _dbContext.Priority.FirstOrDefault(e => e.priority_name == registration.priority),
                Service = _dbContext.Service.FirstOrDefault(e => e.service_name == registration.service)
            };

            _dbContext.Add(newRegistration);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var registration = _dbContext.Registrations.Find(id);

            _dbContext.Registrations.Remove(registration);
            _dbContext.SaveChanges();
        }

        public void Update(RegistrationDTO registration)
        {
            var reg = _dbContext.Registrations.Where(e => e.id == registration.id).FirstOrDefault();
            if(reg != null)
            {
                reg.name = registration.name;
                reg.email = registration.email;
                reg.phone = registration.phone;
                reg.create_date = registration.create_date;
                reg.pickup_date = registration.pickup_date;
                reg.Status = _dbContext.Status.FirstOrDefault(e => e.status_name == registration.status);
                reg.Priority = _dbContext.Priority.FirstOrDefault(e => e.priority_name == registration.priority);
                reg.Service = _dbContext.Service.FirstOrDefault(e => e.service_name == registration.service);
            }

            _dbContext.Entry(reg).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}