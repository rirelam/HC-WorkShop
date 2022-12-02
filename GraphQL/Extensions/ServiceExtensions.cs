using Commons.Contract;
using Commons.Services;
using GrahpQL.Contracts;
using GrahpQL.Presentation.DataLoader;
using GrahpQL.Presentation.Sessions;
using GrahpQL.Presentation.Speakers;
using GrahpQL.Presentation.Tracks;
using GrahpQL.Presentation.Types;
using GraphQL.Repository;
using GraphQL.Services;
using GraphQL.Services.Contracts;
using GraphQL.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GraphQL.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) =>
                        services.AddSingleton<ILoggerManager, LoggerManager>();
        public static void ConfigureDbContextService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPooledDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(ConfigurationConstants.WORKSHOP_CONTEXT),
                b => b.MigrationsAssembly("GraphQL")));
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.TryAddTransient<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.TryAddTransient<IServiceManager, ServiceManager>();

        public static void ConfigureGraphQL(this IServiceCollection services) =>
           services
              .AddGraphQLServer()
              .RegisterService<IServiceManager>(ServiceKind.Synchronized)
              .RegisterService<IRepositoryManager>(ServiceKind.Synchronized)
              .RegisterDbContext<ApplicationDbContext>(DbContextKind.Pooled)
              .AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<SpeakerQueries>()
                .AddTypeExtension<SessionQueries>()
                .AddTypeExtension<TrackQueries>()
              .AddGlobalObjectIdentification()
              .AddMutationType(d => d.Name("Mutation"))
                .AddTypeExtension<SpeakerMutations>()
                .AddTypeExtension<SessionMutations>()
                .AddTypeExtension<TrackMutations>()
              .AddType<SpeakerType>()
              .AddType<SessionType>()
              .AddType<AttendeeType>()
              .AddType<TrackType>()
              .AddDataLoader<SpeakerByIdDataLoader>()
              .AddDataLoader<SessionByIdDataLoader>();
    }
}