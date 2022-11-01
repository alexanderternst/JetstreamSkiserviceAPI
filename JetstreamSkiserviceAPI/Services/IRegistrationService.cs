using JetstreamSkiserviceAPI.DTO;
using JetstreamSkiserviceAPI.Models;

namespace JetstreamSkiserviceAPI.Services
{
    public interface IRegistrationService
    {
        IEnumerable<Registration> GetAll();

        Registration? Get(int id);

        void Add(RegistrationDTO registration);

        void Delete(int id);

        void Update(Registration registration);

    }
}
