
using GraphQL.Entities;

namespace GrahpQL.Contracts
{
    public interface IAttendeeRepository
    {
        void Add(Attendee attendee);
        void UpdateAttendee(Attendee attendee);
        Task<IEnumerable<Attendee>> GetAttendeebyIdsAsync(IReadOnlyList<int> keys);
        Task<Attendee?> GetAttendeeByIdAsync(int attendeeId, CancellationToken cancellationToken);
        Task<ICollection<int>> GetAttendeeSessionsAsync(int attendeeId, CancellationToken cancellationToken);
        IQueryable<Attendee> GetAttendees();
        
    }
}