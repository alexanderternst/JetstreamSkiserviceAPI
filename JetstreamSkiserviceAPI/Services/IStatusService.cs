using JetstreamSkiserviceAPI.DTO;

namespace JetstreamSkiserviceAPI.Services
{
    public interface IStatusService
    {
        List<StatusDTO> GetAll();

        StatusDTO GetStatus(string status);
    }
}
