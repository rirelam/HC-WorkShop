
using System.Reflection;
using GraphQL.Services.Contracts;
using HotChocolate.Types.Descriptors;

namespace GrahpQL.Presentation.Extensions
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseDbContext<IServiceManager>();
        }
    }
}