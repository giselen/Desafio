using Examples.Charge.Application.Facade;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonResponse> FindAllAsync();
        Task<PersonPhoneResponse> FindByIdAsync(int id);
        Task<PersonPhoneResponse> SavePersonPhone(PersonPhone request);
        Task<PersonPhoneResponse> UpdatePersonPhone(int BusinessEntityID, string PhoneNumber, int PhoneNumberTypeID, PersonPhone request);
        Task<int> DeletePersonPhone(int BusinessEntityID, string PhoneNumber, int PhoneNumberTypeID);
    }
}