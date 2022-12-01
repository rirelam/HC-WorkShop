
using GraphQL.Entities;

namespace GrahpQL.Contracts
{
    public interface IAttendeeRepository
    {
        Task<IEnumerable<Attendee>> GetAttendeebyIdsAsync(IReadOnlyList<int> keys);
        Task<ICollection<int>> GetAttendeeSessionsAsync(int attendeeId, CancellationToken cancellationToken);
    }
}