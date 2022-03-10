using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;
        }

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();

        public async Task<List<PersonPhone>> FindByIdAsync(int id) => (await _personPhoneRepository.FindByIdAsync(id)).ToList();

        public async Task<List<PersonPhone>> SavePersonPhone(PersonPhone request) => (await _personPhoneRepository.SavePersonPhone(request)).ToList();

        public async Task<PersonPhone> UpdatePersonPhone(int BusinessEntityID, string PhoneNumber, int PhoneNumberTypeID, PersonPhone request)
        {
            return await _personPhoneRepository.UpdatePersonPhone(BusinessEntityID, PhoneNumber, PhoneNumberTypeID, request);
        }
        public async Task<int> DeletePersonPhone(int BusinessEntityID, string PhoneNumber, int PhoneNumberTypeID)
        {
            return await _personPhoneRepository.DeletePersonPhone(BusinessEntityID, PhoneNumber, PhoneNumberTypeID);
        }
    }
}
