﻿using JetstreamSkiserviceAPI.DTO;
using JetstreamSkiserviceAPI.Models;

namespace JetstreamSkiserviceAPI.Services
{
    public interface IRegistrationService
    {
        List<RegistrationDTO> GetAll();

        RegistrationDTO? Get(int id);

        void Add(RegistrationDTO registration);

        void Delete(int id);

        void Update(RegistrationDTO registration);

    }
}
