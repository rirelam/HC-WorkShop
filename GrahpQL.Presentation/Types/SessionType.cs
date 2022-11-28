
using GrahpQL.Presentation.DataLoader;
using GraphQL.Entities;

namespace GrahpQL.Presentation.Types
{
    public class SessionType : ObjectType<Session>
    {
        protected override void Configure(IObjectTypeDescriptor<Session> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode(async (context, id) =>
                            {
                                Session session =
                                    await context.DataLoader<SessionByIdDataLoader>().LoadAsync(id, context.RequestAborted);

                                return session;
                            });

        }

    }
}