
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GrahpQL.Presentation.DataLoader
{
    public class TrackByIdDataLoader : BatchDataLoader<int, Track>
    {
        private readonly IServiceManager _service;

        public TrackByIdDataLoader(
            IBatchScheduler batchScheduler,
            IServiceManager service)
            : base(batchScheduler)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
        }

        protected override async Task<IReadOnlyDictionary<int, Track>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var tracks = await _service.TrackServices.GetTrackbyIdsAsync(keys);

            return tracks.ToDictionary(s => s.Id);
        }
    }
}