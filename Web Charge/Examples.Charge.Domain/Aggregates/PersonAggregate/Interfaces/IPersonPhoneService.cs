using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        Task<List<PersonPhone>> FindByIdAsync(int id);
        Task<List<PersonPhone>> SavePersonPhone(PersonPhone request);
        Task<PersonPhone> UpdatePersonPhone(int BusinessEntityID, string PhoneNumber, int PhoneNumberTypeID, PersonPhone request);
        Task<int> DeletePersonPhone(int BusinessEntityID, string PhoneNumber, int PhoneNumberTypeID);
    }
}
