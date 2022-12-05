
using GrahpQL.Presentation.DataLoader;
using GraphQL.Entities;

namespace GrahpQL.Presentation.Sessions
{
    [ExtendObjectType("Subscription")]
    public class SessionSubscriptions
    {
        [Subscribe]
        [Topic]
        public Task<Session> OnSessionScheduledAsync(
             [EventMessage] int sessionId,
             SessionByIdDataLoader sessionById,
             CancellationToken cancellationToken) =>
             sessionById.LoadAsync(sessionId, cancellationToken); 
    }
}