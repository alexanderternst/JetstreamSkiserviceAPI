using JetstreamSkiserviceAPI.Models;

namespace JetstreamSkiserviceAPI.Services
{
    public interface IRegistrationService
    {
        List<Registration> GetAll();

        Registration? Get(int id);

        void Add(Registration registration);

        void Delete(int id);

        void Update(int Id, Registration registration);

    }
}
