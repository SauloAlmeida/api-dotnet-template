using Serilog;

namespace Api.Setups
{
    public static class LoggerSetup
    {
        public static ConfigureHostBuilder AddLoggerSetup(this ConfigureHostBuilder host)
        {
            host.UseSerilog((context, configuration) =>
            {
                configuration.ReadFrom.Configuration(context.Configuration);
            });

            return host;
        }

        public static WebApplication UseLoggerForRequests(this WebApplication app)
        {
            app.UseSerilogRequestLogging();

            return app;
        }
    }
}
