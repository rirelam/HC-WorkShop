using System.Diagnostics;
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

        public void Add(Track track) => Create(track);

        public async Task<Track?> FindAsync(int trackId, CancellationToken cancellationToken)
        {
            return await FindByCondition(t=>t.Id==trackId).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Track>> GetTrackbyIdsAsync(IReadOnlyList<int> keys)
        {
            return await FindAll()
                            .Where(s => keys.Contains(s.Id))
                            .ToListAsync();
        }

        public async Task<Track?> GetTrackByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await RepositoryContext.Tracks.Where(t => t.Name == name).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Track>?> GetTrackByNamesAsync(string[] names, CancellationToken cancellationToken)
        {
            return await RepositoryContext.Tracks.Where(t => names.Contains(t.Name)).ToListAsync(cancellationToken);
        }

        public IQueryable<Track> GetTracks()
        {
            return RepositoryContext.Tracks.OrderBy(t => t.Name);
        }

        public async Task<ICollection<int>> GetTrackSessionsAsync(int trackId, CancellationToken cancellationToken)
        {
            return await RepositoryContext.Sessions
                    .Where(s => s.TrackId == trackId)
                    .Select(s => s.Id)
                    .ToArrayAsync(cancellationToken);
        }

        public void UpdateTrack(Track track) => Update(track);
    }
}