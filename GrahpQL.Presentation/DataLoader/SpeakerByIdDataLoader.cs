
using GraphQL.Entities;
using GraphQL.Services.Contracts;
using Microsoft.EntityFrameworkCore;

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

        protected override async Task<IReadOnlyDictionary<int, Speaker>?> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            var speakers = await _service.SpeakerServices.GetAllSpeakersAsync() as IQueryable<Speaker>;
            return await speakers?
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}