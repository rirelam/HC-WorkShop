using GraphQL.Entities;

namespace GraphQL.Services.Contracts
{
    public interface ITrackServices
    {
        Task<IEnumerable<Track>> GetTrackbyIdsAsync(IReadOnlyList<int> keys);
        Task<ICollection<int>> GetTrackSessionsAsync(int trackId, CancellationToken cancellationToken);
        Task AddAsync(Track track);
        Task UpdateTrackAsync(Track track);
        Task<Track?> FindAsync(int trackId, CancellationToken cancellationToken);
        IQueryable<Track> GetTracks();
        Task<Track?> GetTrackByNameAsync(string name, CancellationToken cancellationToken);
        Task<IEnumerable<Track>?> GetTrackByNamesAsync(string[] names, CancellationToken cancellationToken);

    }
}