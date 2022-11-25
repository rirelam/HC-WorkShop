
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GrahpQL.Presentation.DataLoader
{
    public class SessionByIdDataLoader : BatchDataLoader<int, Session>
    {
        private readonly IServiceManager _service;


        public SessionByIdDataLoader(
            IBatchScheduler batchScheduler,
            IServiceManager service)
            : base(batchScheduler)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
        }

        protected override async Task<IReadOnlyDictionary<int, Session>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            return await _service.SessionServices.GetSessionDictionaryAsync(keys, cancellationToken);
        }
    }
}