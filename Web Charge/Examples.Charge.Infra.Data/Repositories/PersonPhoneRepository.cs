using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync()
        {
            return (IEnumerable<PersonPhone>)await Task.Run(() => _context.PersonPhone);
        }

        public async Task<IEnumerable<PersonPhone>> FindByIdAsync(int id)
        {
            return (IEnumerable<PersonPhone>)await Task.Run(() => _context.PersonPhone.Where(s => s.PhoneNumberTypeID == id));
        }

        public async Task<IEnumerable<PersonPhone>> SavePersonPhone(PersonPhone request)
        {
            _context.PersonPhone.Add(request);
            await _context.SaveChangesAsync();

            return (IEnumerable<PersonPhone>)request;
        }

        public async Task<PersonPhone> UpdatePersonPhone(int BusinessEntityID, string PhoneNumber, int PhoneNumberTypeID, PersonPhone request)
        {

            object[] InfoPerson = new object[] { BusinessEntityID, PhoneNumber, PhoneNumberTypeID };

            var removePerson = await _context.PersonPhone.FindAsync(InfoPerson);

            _context.Remove(removePerson);
            await _context.SaveChangesAsync();

            await _context.AddAsync(request);
            await _context.SaveChangesAsync();

            return request;
        }

        public async Task<int> DeletePersonPhone(int BusinessEntityID, string PhoneNumber, int PhoneNumberTypeID)
        {
            object[] InfoPerson = new object[] { BusinessEntityID, PhoneNumber, PhoneNumberTypeID };

            var removePerson = await _context.PersonPhone.FindAsync(InfoPerson);

            _context.Remove(removePerson);

            return await _context.SaveChangesAsync();
        }
    }
}
