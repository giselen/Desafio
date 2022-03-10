using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        private readonly IPersonPhoneService _personPhoneService;

        public PersonFacade(IPersonService personService, IMapper mapper, IPersonPhoneService personPhoneService)
        {
            _personService = personService;
            _mapper = mapper;
            _personPhoneService = personPhoneService;
        }

        public async Task<PersonResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonResponse();
            response.PersonObjects = new List<PersonDto>();
            response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
            return response;
        }

        public async Task<PersonPhoneResponse> FindByIdAsync(int id)
        {
            var result = await _personPhoneService.FindByIdAsync(id);
            var response = new PersonPhoneResponse();
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            response.PersonPhoneObjects.AddRange(result.Select(x => _mapper.Map<PersonPhoneDto>(x)));
            return response;
        }

        public async Task<PersonPhoneResponse> SavePersonPhone(PersonPhone request)
        {
            var result = await _personPhoneService.SavePersonPhone(request);
            var response = new PersonPhoneResponse();
            return response;
        }

        public async Task<PersonPhoneResponse> UpdatePersonPhone(int BusinessEntityID, string PhoneNumber, int PhoneNumberTypeID, PersonPhone request)
        {
            var resultado = await _personPhoneService.UpdatePersonPhone(BusinessEntityID, PhoneNumber, PhoneNumberTypeID, request);
            var response = new PersonPhoneResponse();
            return response;
        }

        public async Task<int> DeletePersonPhone(int BusinessEntityID, string PhoneNumber, int PhoneNumberTypeID)
        {
            var resultado = await _personPhoneService.DeletePersonPhone(BusinessEntityID, PhoneNumber, PhoneNumberTypeID);
            return resultado;
        }

    }
}
