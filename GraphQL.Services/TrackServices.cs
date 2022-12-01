
using GrahpQL.Contracts;
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GraphQL.Services
{
    public class TrackServices : ITrackServices
    {
        private readonly IRepositoryManager _repository;

        public TrackServices(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Track>> GetTrackbyIdsAsync(IReadOnlyList<int> keys)
        {
            return await _repository.Track.GetTrackbyIdsAsync(keys);
        }
    }
}