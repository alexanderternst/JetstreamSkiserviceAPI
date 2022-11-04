using JetstreamSkiserviceAPI.DTO;
using JetstreamSkiserviceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JetstreamSkiserviceAPI.Services
{
    public class StatusServiceSQL : IStatusService
    {
        private readonly RegistrationContext _dbContext;
        public List<Status> Status = new List<Status>();

        public StatusServiceSQL(RegistrationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<StatusDTO> GetAll()
        {
            Status = _dbContext.Status.Include("registrations").Include("registrations.Priority").Include("registrations.Service").ToList();

            List<StatusDTO> result = new List<StatusDTO>();

            foreach (var s in Status)
            {
                var status = new StatusDTO();
                status.status_id = s.status_id;
                status.status_name = s.status_name;

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

                    status.registration.Add(rdto); // fehler 
                }
                result.Add(status);
            }
            return result;
        }

        public StatusDTO GetStatus(string status)
        {
            List<StatusDTO> t = GetAll();

            StatusDTO r = t.Find(p => p.status_name == status);

            return r;
        }
    }
}
