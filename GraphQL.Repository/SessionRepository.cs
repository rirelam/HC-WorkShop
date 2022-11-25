
using GrahpQL.Contracts;
using GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Repository
{
    public class SessionRepository : RepositoryBase<Session>, ISessionRepository
    {
        public SessionRepository(ApplicationDbContext repositoryContext)
        : base(repositoryContext)
        {

        }

        public async Task<IReadOnlyDictionary<int, Session>> GetSessionDictionaryAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            if (keys == null)
            {
                return await RepositoryContext.Sessions.Where(sp=> 1==2).ToDictionaryAsync(t => t.Id, cancellationToken);
            }
            return await RepositoryContext.Sessions
                        .Where(sp => keys.Contains(sp.Id))
                        .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}