
using GraphQL.Entities;

namespace GraphQL.Services.Contracts
{
    public interface IAttendeeServices
    {
        Task<IEnumerable<Attendee>> GetAttendeebyIdsAsync(IReadOnlyList<int> keys);
        Task<ICollection<int>> GetAttendeeSessionsAsync(int attendeeId, CancellationToken cancellationToken);
        IQueryable<Attendee> GetAttendees();
        Task Add(Attendee attendee);
        Task<Attendee?> GetAttendeeByIdAsync(int attendeeId, CancellationToken cancellationToken);
        Task UpdateAttendee(Attendee attendee, CancellationToken cancellationToken);

    }
}