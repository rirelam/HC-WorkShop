using GrahpQL.Contracts;
using GraphQL.Repository;
using GraphQL.Services;
using GraphQL.Services.Contracts;
using GraphQL.Shared.Constants;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContextService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(ConfigurationConstants.WORKSHOP_CONTEXT),
                b => b.MigrationsAssembly("GraphQL")));
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
    }
}