using GraphQL.Entities;

namespace GraphQL.Services.Contracts
{
    public interface ITrackServices
    {
        Task<IEnumerable<Track>> GetTrackbyIdsAsync(IReadOnlyList<int> keys);

    }
}