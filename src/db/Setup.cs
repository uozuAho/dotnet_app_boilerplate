using boilerplate.db.Models;
using Marten;
using Microsoft.Extensions.DependencyInjection;

namespace boilerplate.db
{
    public static class ServiceExtensions
    {
        public static void AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IDocumentStore>(_ => DocumentStore.For(_ =>
            {
                _.Connection(connectionString);

                _.Schema.For<Animal>()
                    .AddSubClass<Person>()
                    .AddSubClass<Dog>();
            }));
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<PersonRepository>();
            services.AddScoped<DogRepository>();
            services.AddScoped<AnimalRepository>();
        }
    }
}
