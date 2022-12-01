
using GraphQL.Entities;

namespace GrahpQL.Contracts
{
    public interface ITrackRepository
    {
        Task<IEnumerable<Track>> GetTrackbyIdsAsync(IReadOnlyList<int> keys);
        Task<ICollection<int>> GetTrackSessionsAsync(int trackId, CancellationToken cancellationToken);

    }
}