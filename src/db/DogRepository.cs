using System;
using System.Linq;
using System.Threading.Tasks;
using boilerplate.db.Models;
using Marten;

namespace boilerplate.db
{
    public class DogRepository
    {
        private readonly IDocumentStore _store;

        public DogRepository(IDocumentStore store)
        {
            _store = store;
        }

        public async Task Save(Dog dog)
        {
            using var session = _store.LightweightSession();

            session.Store(dog);

            await session.SaveChangesAsync();
        }

        public async Task<Dog> Load(Guid id)
        {
            using var session = _store.LightweightSession();

            return await session
                .Query<Dog>()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
