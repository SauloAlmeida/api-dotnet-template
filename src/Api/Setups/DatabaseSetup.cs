using Application.Common.Interfaces;
using Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Api.Setups
{
    public static class DatabaseSetup
    {
        public static IServiceCollection AddDatabasesSetup(this IServiceCollection services, 
                                                                IConfiguration configuration)
        {
            services.AddDbConnection(configuration); 
            return services;
        }

        public static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = configuration.GetConnectionString("");
            
            //services.AddDbContext<IAppDatabaseContext, AppDatabaseContext>(opt => opt.UseSqlServer(connectionString));

            services.AddDbContext<IAppDatabaseContext, AppDatabaseContext>(opt => opt.UseInMemoryDatabase(nameof(AppDatabaseContext)));

            return services;
        }
    }
}
