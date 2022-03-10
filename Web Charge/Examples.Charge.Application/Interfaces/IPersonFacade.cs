﻿using Examples.Charge.Application.Facade;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonResponse> FindAllAsync();
        Task<PersonPhoneResponse> FindByIdAsync(int id);
    }
}