using JetstreamSkiserviceAPI.DTO;

namespace JetstreamSkiserviceAPI.Services
{
    /// <summary>
    /// Interface für StatusSevrice
    /// </summary>
    public interface IStatusService
    {
        List<StatusDTO> GetAll();

        StatusDTO GetStatus(string status);
    }
}
