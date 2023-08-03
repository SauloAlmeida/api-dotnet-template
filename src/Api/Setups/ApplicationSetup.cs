using Application;
using Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace Api.Setups
{
    public static class ApplicationSetup
    {
        public static IServiceCollection AddAplicationSetup(this IServiceCollection services)
        {
            Assembly applicationAssembly = typeof(ApplicationAssembly).Assembly;

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));

            services.AddValidatorsFromAssembly(applicationAssembly);

            return services;
        }
    }
}
