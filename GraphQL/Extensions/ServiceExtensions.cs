using GrahpQL.Contracts;
using GrahpQL.Presentation.DataLoader;
using GrahpQL.Presentation.Mutations;
using GrahpQL.Presentation.Queries;
using GrahpQL.Presentation.Types;
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
            services.AddPooledDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(ConfigurationConstants.WORKSHOP_CONTEXT),
                b => b.MigrationsAssembly("GraphQL")));
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddTransient<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddTransient<IServiceManager, ServiceManager>();

        public static void ConfigureGraphQL(this IServiceCollection services) =>
           services
              .AddGraphQLServer()
              .AddQueryType<Query>()
              .AddMutationType<Mutation>()
              .AddType<SpeakerType>()
              .AddDataLoader<SpeakerByIdDataLoader>()
              .AddDataLoader<SessionByIdDataLoader>();
    }
}