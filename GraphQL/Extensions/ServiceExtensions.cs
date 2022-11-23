using GraphQL.Repository;
using GraphQL.Shared.Constants;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContextService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(configuration.GetConnectionString(ConfigurationConstants.WORKSHOP_CONTEXT)));
        }
    }
}