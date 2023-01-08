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
                    Id = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    Phone = e.Phone,
                    CreateDate = e.Create_date,
                    PickupDate = e.Pickup_date,
                    Status = e.Status.Status_name,
                    Priority = e.Priority.Priority_name,
                    Service = e.Service.Service_name,
                    Comment = e.Comment,
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

                RegistrationDTO reg = e.Find(p => p.Id == id);

                if (reg == null)
                    throw new Exception("Item does not exist");

                return new RegistrationDTO()
                {
                    Id = reg.Id,
                    Name = reg.Name,
                    Phone = reg.Phone,
                    Email = reg.Email,
                    CreateDate = reg.CreateDate,
                    PickupDate = reg.PickupDate,
                    Service = reg.Service,
                    Priority = reg.Priority,
                    Status = reg.Status,
                    Comment = reg.Comment,
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
                    Name = registration.Name,
                    Email = registration.Email,
                    Phone = registration.Phone,
                    Create_date = registration.CreateDate,
                    Pickup_date = registration.PickupDate,
                    Status = _dbContext.Status.FirstOrDefault(e => e.Status_name == registration.Status),
                    Priority = _dbContext.Priority.FirstOrDefault(e => e.Priority_name == registration.Priority),
                    Service = _dbContext.Service.FirstOrDefault(e => e.Service_name == registration.Service),
                    Comment = registration.Comment
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
                var reg = _dbContext.Registrations.Where(e => e.Id == registration.Id).FirstOrDefault();
                if (reg != null)
                {
                    reg.Name = registration.Name;
                    reg.Email = registration.Email;
                    reg.Phone = registration.Phone;
                    reg.Create_date = registration.CreateDate;
                    reg.Pickup_date = registration.PickupDate;
                    reg.Status = _dbContext.Status.FirstOrDefault(e => e.Status_name == registration.Status);
                    reg.Priority = _dbContext.Priority.FirstOrDefault(e => e.Priority_name == registration.Priority);
                    reg.Service = _dbContext.Service.FirstOrDefault(e => e.Service_name == registration.Service);
                    reg.Comment = registration.Comment;
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