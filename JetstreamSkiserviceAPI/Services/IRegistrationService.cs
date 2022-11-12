using JetstreamSkiserviceAPI.DTO;

namespace JetstreamSkiserviceAPI.Services
{
    /// <summary>
    /// Interface für RegistrationService
    /// </summary>
    public interface IRegistrationService
    {
        List<RegistrationDTO> GetAll();

        RegistrationDTO Get(int id);

        void Add(RegistrationDTO registration);

        void Delete(int id);

        void Update(RegistrationDTO registration);

    }
}
