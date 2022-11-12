namespace JetstreamSkiserviceAPI.DTO
{
    /// <summary>
    /// DTO Klasse für Stati
    /// </summary>
    public class StatusDTO
    {
        public int status_id { get; set; }
        public string status_name { get; set; }
        public List<RegistrationDTO> registration { get; set; } = new List<RegistrationDTO>();
    }
}
