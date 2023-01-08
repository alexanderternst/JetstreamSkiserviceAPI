using JetstreamSkiserviceAPI.DTO;
using JetstreamSkiserviceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JetstreamSkiserviceAPI.Services
{
    /// <summary>
    /// Status Service für abrufen von Registrationen nach Status
    /// </summary>
    public class StatusServiceSQL : IStatusService
    {
        private readonly RegistrationContext _dbContext;
        public List<Status> Status = new List<Status>();

        /// <summary>
        /// Konstruktor für instanziierung von SQL Server verbindung
        /// </summary>
        /// <param name="dbContext">RegistrationContext</param>
        public StatusServiceSQL(RegistrationContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// GetAll Methode welche Registrationen, gruppiert nach Status zurückgibt
        /// </summary>
        /// <returns>Liste von StatusDTO</returns>
        /// <exception cref="Exception"></exception>
        public List<StatusDTO> GetAll()
        {
            try
            {

                Status = _dbContext.Status.Include("registrations").Include("registrations.Priority").Include("registrations.Service").ToList();

                List<StatusDTO> result = new List<StatusDTO>();

                // ForEach für abrufen von Status (StatusName, StatusId)
                foreach (var s in Status)
                {
                    var status = new StatusDTO();
                    status.StatusId = s.Status_id;
                    status.StatusName = s.Status_name;

                    // ForEach von abrufen von Registrationen für jeden Status (Registrationen)
                    foreach (var r in s.Registrations)
                    {
                        RegistrationDTO rdto = new RegistrationDTO();

                        rdto.Id = r.Id;
                        rdto.Name = r.Name;
                        rdto.Email = r.Email;
                        rdto.Phone = r.Phone;
                        rdto.CreateDate = r.Create_date;
                        rdto.PickupDate = r.Pickup_date;

                        rdto.Priority = r.Priority.Priority_name;
                        rdto.Service = r.Service.Service_name;
                        rdto.Status = s.Status_name;

                        rdto.Comment = r.Comment;

                        status.Registrations.Add(rdto);
                    }
                    result.Add(status);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// GetStatus Methode welche Registrationen, nach spezifischem Status ausgibt
        /// </summary>
        /// <param name="status"></param>
        /// <returns>StatusDTO</returns>
        /// <exception cref="Exception"></exception>
        public StatusDTO GetStatus(string status)
        {
            try
            {
                // GetAll abruf
                List<StatusDTO> reg = GetAll();

                // Abrufen von Registrationen nach spezifischem Status
                StatusDTO result = reg.Find(p => p.StatusName == status);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
