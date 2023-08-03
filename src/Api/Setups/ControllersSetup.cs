using Api.Middlewares;

namespace Api.Setups
{
    public static class ControllersSetup
    {
        public static IServiceCollection AddControllersSetup(this IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add(typeof(ExceptionMiddleware)));
            services.AddSwagger();

            return services;
        }

        private static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }

        public static WebApplication UseDocumentation(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }
    }
}
