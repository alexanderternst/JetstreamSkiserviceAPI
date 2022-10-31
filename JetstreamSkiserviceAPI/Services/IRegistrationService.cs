using JetstreamSkiserviceAPI.Models;

namespace JetstreamSkiserviceAPI.Services
{
    public interface IRegistrationService
    {
        IEnumerable<Registration> GetAll();

        Registration? Get(int id);

        void Add(Registration registration);

        void Delete(int id);

        void Update(Registration registration);

    }
}
