using System;
using Jaeger;
using Jaeger.Reporters;
using Jaeger.Samplers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
                var loggerFactory = _.GetRequiredService<ILoggerFactory>();
                var tracer = new Tracer.Builder("boilerplate.api")
                    // .WithLoggerFactory(loggerFactory)
                    // .WithSampler(new ConstSampler(true))
                    .Build();

                GlobalTracer.Register(tracer);

                return tracer;
            });

            return services;
        }
    }
}
