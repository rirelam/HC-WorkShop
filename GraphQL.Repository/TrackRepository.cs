using GrahpQL.Contracts;
using GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Repository
{
    public class TrackRepository : RepositoryBase<Track>, ITrackRepository
    {
        public TrackRepository(ApplicationDbContext repositoryContext)
                : base(repositoryContext)
        {

        }


        public async Task<IEnumerable<Track>> GetTrackbyIdsAsync(IReadOnlyList<int> keys)
        {
            return await FindAll()
                            .Where(s => keys.Contains(s.Id))
                            .ToListAsync();
        }

        public async Task<ICollection<int>> GetTrackSessionsAsync(int trackId, CancellationToken cancellationToken)
        {
            return await RepositoryContext.Sessions
                    .Where(s => s.TrackId == trackId)
                    .Select(s => s.Id)
                    .ToArrayAsync(cancellationToken);
        }
    }
}