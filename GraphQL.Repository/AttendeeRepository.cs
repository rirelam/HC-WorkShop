
using GrahpQL.Contracts;
using GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Repository
{
    public class AttendeeRepository : RepositoryBase<Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(ApplicationDbContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public async  Task<IEnumerable<Attendee>> GetAttendeebyIdsAsync(IReadOnlyList<int> keys)
        {
            return await FindAll()
                            .Where(s => keys.Contains(s.Id))
                            .ToListAsync();
        }

        public async Task<ICollection<int>> GetAttendeeSessionsAsync(int attendeeId, CancellationToken cancellationToken)
        {
            return await RepositoryContext.Attendees
                    .Where(s => s.Id == attendeeId)
                    .Include(s => s.SessionsAttendees)
                    .SelectMany(s => s.SessionsAttendees.Select(t => t.SessionId))
                    .ToArrayAsync(cancellationToken);
        }
    }
}