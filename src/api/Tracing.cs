using Jaeger;
using Microsoft.Extensions.DependencyInjection;
using OpenTracing;
using OpenTracing.Util;

namespace boilerplate.api
{
    public static class Tracing
    {
        public static IServiceCollection AddTracing(this IServiceCollection services)
        {
            services.AddOpenTracing();

            services.AddSingleton<ITracer>(_ =>
            {
                var tracer = new Tracer.Builder("boilerplate.api").Build();

                GlobalTracer.Register(tracer);

                return tracer;
            });

            return services;
        }
    }
}
