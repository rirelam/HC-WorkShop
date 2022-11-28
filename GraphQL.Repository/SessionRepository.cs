
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

        public async Task<IEnumerable<Session>> GetAllSessionsAsync(bool AsTraking = false)
        {
            return await FindAll(AsTraking).ToListAsync();
        }

        public async Task<IEnumerable<Session>> GetSessionByIdsAsync(IReadOnlyList<int> keys)
        {
            return await FindAll()
                         .Where(s => keys.Contains(s.Id))
                         .ToListAsync();
        }

    }
}