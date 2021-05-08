using System;
using System.Linq;
using System.Threading.Tasks;
using boilerplate.db.Models;
using Marten;

namespace boilerplate.db
{
    public class PersonRepository
    {
        private readonly IDocumentStore _store;

        public PersonRepository(IDocumentStore store)
        {
            _store = store;
        }

        public async Task SavePerson(Person person)
        {
            using var session = _store.LightweightSession();

            session.Store(person);

            await session.SaveChangesAsync();
        }

        public async Task<Person> LoadPerson(Guid id)
        {
            using var session = _store.LightweightSession();

            return await session
                .Query<Person>()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
