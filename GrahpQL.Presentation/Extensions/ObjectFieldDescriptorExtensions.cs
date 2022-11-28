
using GraphQL.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace GrahpQL.Presentation.Extensions
{
    public static class ObjectFieldDescriptorExtensions
    {
        public static IObjectFieldDescriptor UseDbContext<TDbContext>(
            this IObjectFieldDescriptor descriptor)
            where TDbContext : IServiceManager
        {
            return descriptor.UseScopedService(
                create: s => s.GetRequiredService<TDbContext>(),
                disposeAsync: (s, c) => c.DisposeAsync());
        }
    }
}