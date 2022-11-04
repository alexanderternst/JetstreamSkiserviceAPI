using JetstreamSkiserviceAPI.DTO;
using JetstreamSkiserviceAPI.Models;

namespace JetstreamSkiserviceAPI.Services
{
    public interface IStatusService
    {
        List<StatusDTO> GetAll();

        StatusDTO GetStatus(string status);
    }
}
