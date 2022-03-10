using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<PersonPhone>> FindByIdAsync()
        {
            return (IEnumerable<PersonPhone>)await Task.Run(() => _context.PersonPhone);
        }
    }
}
