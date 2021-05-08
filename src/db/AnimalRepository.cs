using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using boilerplate.db.Models;
using Marten;

namespace boilerplate.db
{
    public class AnimalRepository
    {
        private readonly IDocumentStore _store;

        public AnimalRepository(IDocumentStore store)
        {
            _store = store;
        }

        public async Task<IEnumerable<Animal>> LoadAll()
        {
            using var session = _store.LightweightSession();

            return await session
                .Query<Animal>()
                .ToListAsync();
        }
    }
}
