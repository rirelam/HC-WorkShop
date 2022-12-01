
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GrahpQL.Presentation.DataLoader
{
    public class AttendeeByIdDataLoader : BatchDataLoader<int, Attendee>
    {
        private readonly IServiceManager _service;

        public AttendeeByIdDataLoader(
            IBatchScheduler batchScheduler,
            IServiceManager service)
            : base(batchScheduler)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
        }

        protected override async Task<IReadOnlyDictionary<int, Attendee>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            var attendees = await _service.AttendeeServices.GetAttendeebyIdsAsync(keys);

            return attendees.ToDictionary(s => s.Id);
        }

    }
}