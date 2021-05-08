using Marten;
using Microsoft.Extensions.DependencyInjection;

namespace boilerplate.db
{
    public static class ServiceExtensions
    {
        public static void AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddMarten(connectionString);
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<PersonRepository>();
            services.AddScoped<DogRepository>();
        }
    }
}
