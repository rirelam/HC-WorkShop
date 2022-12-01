
using GraphQL.Entities;

namespace GraphQL.Services.Contracts
{
    public interface IAttendeeServices
    {
        Task<IEnumerable<Attendee>> GetAttendeebyIdsAsync(IReadOnlyList<int> keys);
        Task<ICollection<int>> GetAttendeeSessionsAsync(int attendeeId, CancellationToken cancellationToken);

    }
}