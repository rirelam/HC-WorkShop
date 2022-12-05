
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

        public void Add(Attendee attendee) => Create(attendee);

        public async Task<Attendee?> GetAttendeeByIdAsync(int attendeeId, CancellationToken cancellationToken)
        {
            return await FindByCondition(a => a.Id == attendeeId).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Attendee>> GetAttendeebyIdsAsync(IReadOnlyList<int> keys)
        {
            return await FindAll()
                            .Where(s => keys.Contains(s.Id))
                            .ToListAsync();
        }

        public IQueryable<Attendee> GetAttendees()
        {
            return FindAll();
        }

        public async Task<ICollection<int>> GetAttendeeSessionsAsync(int attendeeId, CancellationToken cancellationToken)
        {
            return await RepositoryContext.Attendees
                    .Where(s => s.Id == attendeeId)
                    .Include(s => s.SessionsAttendees)
                    .SelectMany(s => s.SessionsAttendees.Select(t => t.SessionId))
                    .ToArrayAsync(cancellationToken);
        }

        public void UpdateAttendee(Attendee attendee) => Update(attendee);
    }
}