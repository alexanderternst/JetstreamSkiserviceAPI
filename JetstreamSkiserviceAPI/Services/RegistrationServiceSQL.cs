using Microsoft.EntityFrameworkCore;
using JetstreamSkiserviceAPI.Models;
using JetstreamSkiserviceAPI.DTO;

namespace JetstreamSkiserviceAPI.Services
{
    /// <summary>
    /// Registration Service für RegisrationController
    /// </summary>
    public class RegistrationServiceSQL : IRegistrationService
    {
        private readonly RegistrationContext _dbContext;

        public List<Registration> registrations = new List<Registration>();

        /// <summary>
        /// Konstruktor für instanziierung von SQL Server verbindung
        /// </summary>
        /// <param name="dbContext">RegistrationContext</param>
        public RegistrationServiceSQL(RegistrationContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// GetAll Methode welche alle Registrationen ausliest/zurückgibt
        /// </summary>
        /// <returns>Liste von RegistrationDTO</returns>
        /// <exception cref="Exception"></exception>
        public List<RegistrationDTO> GetAll()
        {
            try
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
                    service = e.Service.service_name,
                    comment = e.comment,
                }));

                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// GetById Methode welche Registration nach bestimmter id ausliest/zurückgibt
        /// </summary>
        /// <param name="id">erwartet id</param>
        /// <returns>RegistrationDTO</returns>
        /// <exception cref="Exception"></exception>
        public RegistrationDTO Get(int id)
        {
            try
            {
                List<RegistrationDTO> e = GetAll();

                RegistrationDTO reg = e.Find(p => p.id == id);

                if (reg == null)
                    throw new Exception("Item does not exist");

                return new RegistrationDTO()
                {
                    id = reg.id,
                    name = reg.name,
                    phone = reg.phone,
                    email = reg.email,
                    create_date = reg.create_date,
                    pickup_date = reg.pickup_date,
                    service = reg.service,
                    priority = reg.priority,
                    status = reg.status,
                    comment = reg.comment,
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Add Methode für hinzufügen von Eintrag in Registration
        /// </summary>
        /// <param name="registration">erwartet registration</param>
        /// <exception cref="Exception"></exception>
        public void Add(RegistrationDTO registration)
        {
            try
            {
                Registration reg = new Registration()
                {
                    name = registration.name,
                    email = registration.email,
                    phone = registration.phone,
                    create_date = registration.create_date,
                    pickup_date = registration.pickup_date,
                    Status = _dbContext.Status.FirstOrDefault(e => e.status_name == registration.status),
                    Priority = _dbContext.Priority.FirstOrDefault(e => e.priority_name == registration.priority),
                    Service = _dbContext.Service.FirstOrDefault(e => e.service_name == registration.service),
                    comment = registration.comment
                };

                _dbContext.Add(reg);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete Methode für löschen von Eintrag in Registration
        /// </summary>
        /// <param name="id">erwartet id</param>
        /// <exception cref="Exception"></exception>
        public void Delete(int id)
        {
            try
            {
                var reg = _dbContext.Registrations.Find(id);

                _dbContext.Registrations.Remove(reg);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update Methode für modifizieren von Eintrag in Registrationen
        /// </summary>
        /// <param name="registration">erwartet registration</param>
        /// <exception cref="Exception"></exception>
        public void Update(RegistrationDTO registration)
        {
            try
            {
                var reg = _dbContext.Registrations.Where(e => e.id == registration.id).FirstOrDefault();
                if (reg != null)
                {
                    reg.name = registration.name;
                    reg.email = registration.email;
                    reg.phone = registration.phone;
                    reg.create_date = registration.create_date;
                    reg.pickup_date = registration.pickup_date;
                    reg.Status = _dbContext.Status.FirstOrDefault(e => e.status_name == registration.status);
                    reg.Priority = _dbContext.Priority.FirstOrDefault(e => e.priority_name == registration.priority);
                    reg.Service = _dbContext.Service.FirstOrDefault(e => e.service_name == registration.service);
                    reg.comment = registration.comment;
                }

                _dbContext.Entry(reg).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}