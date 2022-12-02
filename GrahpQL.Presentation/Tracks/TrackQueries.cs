
using GrahpQL.Presentation.DataLoader;
using GraphQL.Entities;
using GraphQL.Services.Contracts;


namespace GrahpQL.Presentation.Tracks
{
    [ExtendObjectType("Query")]
    public class TrackQueries
    {
        public async Task<IEnumerable<Track>> GetTracksAsync(
        IServiceManager service,
        CancellationToken cancellationToken) =>
        await service.TrackServices.GetTracksAsync(cancellationToken);

        public async Task<Track?> GetTrackByNameAsync(
            string name,
            IServiceManager service,
            CancellationToken cancellationToken) =>
            await service.TrackServices.GetTrackByNameAsync(name, cancellationToken);

        public async Task<IEnumerable<Track>?> GetTrackByNamesAsync(
            string[] names,
            IServiceManager service,
            CancellationToken cancellationToken) =>
            await service.TrackServices.GetTrackByNamesAsync(names, cancellationToken);

        public Task<Track> GetTrackByIdAsync(
            [ID(nameof(Track))] int id,
            TrackByIdDataLoader trackById,
            CancellationToken cancellationToken) =>
            trackById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Track>> GetTracksByIdAsync(
            [ID(nameof(Track))] int[] ids,
            TrackByIdDataLoader trackById,
            CancellationToken cancellationToken) =>
            await trackById.LoadAsync(ids, cancellationToken);
    }
}