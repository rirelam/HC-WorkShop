
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

        public async Task AddAsync(Track track)
        {
            _repository.Track.Add(track);
            await _repository.SaveAsync();
        }

        public async Task<Track?> FindAsync(int trackId, CancellationToken cancellationToken)
        {
           return await _repository.Track.FindAsync(trackId, cancellationToken);
        }

        public async Task<IEnumerable<Track>> GetTrackbyIdsAsync(IReadOnlyList<int> keys)
        {
            return await _repository.Track.GetTrackbyIdsAsync(keys);
        }

        public async Task<Track?> GetTrackByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _repository.Track.GetTrackByNameAsync(name, cancellationToken);
        }

        public async Task<IEnumerable<Track>?> GetTrackByNamesAsync(string[] names, CancellationToken cancellationToken)
        {
            return await _repository.Track.GetTrackByNamesAsync(names, cancellationToken);
        }

        public async Task<IEnumerable<Track>> GetTracksAsync(CancellationToken cancellationToken)
        {
            return await _repository.Track.GetTracksAsync(cancellationToken);
        }

        public async Task<ICollection<int>> GetTrackSessionsAsync(int trackId, CancellationToken cancellationToken)
        {
            return await _repository.Track.GetTrackSessionsAsync(trackId, cancellationToken);
        }

        public async Task UpdateTrackAsync(Track track)
        {
            _repository.Track.UpdateTrack(track);
            await _repository.SaveAsync();
        }
    }
}