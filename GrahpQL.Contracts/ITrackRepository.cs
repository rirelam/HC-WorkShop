
using GraphQL.Entities;

namespace GrahpQL.Contracts
{
    public interface ITrackRepository
    {
        Task<IEnumerable<Track>> GetTrackbyIdsAsync(IReadOnlyList<int> keys);
        Task<ICollection<int>> GetTrackSessionsAsync(int trackId, CancellationToken cancellationToken);
        void Add(Track track);
        void UpdateTrack(Track track);
        Task<Track?> FindAsync(int trackId, CancellationToken cancellationToken);
        IQueryable<Track> GetTracks();
        Task<Track?> GetTrackByNameAsync(string name, CancellationToken cancellationToken);
        Task<IEnumerable<Track>?> GetTrackByNamesAsync(string[] names, CancellationToken cancellationToken);
    }
}