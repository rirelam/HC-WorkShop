
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GrahpQL.Presentation.DataLoader
{
    public class SpeakerByIdDataLoader : BatchDataLoader<int, Speaker>
    {
        private readonly IServiceManager _service;
        
        public SpeakerByIdDataLoader(
            IBatchScheduler batchScheduler,
            IServiceManager service)
            : base(batchScheduler)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
        }

        protected override async Task<IReadOnlyDictionary<int, Speaker>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            var speakers = await _service.SpeakerServices.GetSpeakerbyIdsAsync(keys);

            return speakers.ToDictionary(s => s.Id);
        }
    }
}