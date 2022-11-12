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
                    status.status_id = s.status_id;
                    status.status_name = s.status_name;

                    // ForEach von abrufen von Registrationen für jeden Status (Registrationen)
                    foreach (var r in s.registrations)
                    {
                        RegistrationDTO rdto = new RegistrationDTO();

                        rdto.id = r.id;
                        rdto.name = r.name;
                        rdto.email = r.email;
                        rdto.phone = r.phone;
                        rdto.create_date = r.create_date;
                        rdto.pickup_date = r.pickup_date;

                        rdto.priority = r.Priority.priority_name;
                        rdto.service = r.Service.service_name;
                        rdto.status = s.status_name;

                        rdto.comment = r.comment;

                        status.registration.Add(rdto);
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
                StatusDTO result = reg.Find(p => p.status_name == status);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
