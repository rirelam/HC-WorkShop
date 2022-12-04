
using GrahpQL.Presentation.DataLoader;
using GrahpQL.Presentation.Types;
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GrahpQL.Presentation.Sessions
{
    [ExtendObjectType("Query")]
    public class SessionQueries
    {
        [UsePaging(typeof(NonNullType<SessionType>))]
        [UseFiltering(typeof(SessionFilterInputType))]
        [UseSorting]
        public IQueryable<Session> GetSessions(
         IServiceManager service) =>
          service.SessionServices.GetAllSessions();

        public Task<Session> GetSessionByIdAsync(
            [ID(nameof(Session))] int id,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken) =>
            sessionById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Session>> GetSessionsByIdAsync(
            [ID(nameof(Session))] int[] ids,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken) =>
            await sessionById.LoadAsync(ids, cancellationToken); 
    }
}