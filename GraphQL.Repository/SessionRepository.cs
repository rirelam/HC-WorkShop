
using GrahpQL.Contracts;
using GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Repository
{
    public class SessionRepository : RepositoryBase<Session>, ISessionRepository
    {
        public SessionRepository(ApplicationDbContext repositoryContext)
        : base(repositoryContext)
        {

        }

        public void AddSession(Session session) => Create(session);

        public IQueryable<Session> FindAsync(int sessionId)
        {
            return  FindByCondition(s => s.Id == sessionId);
        }

        public IQueryable<Session> GetAllSessions(bool AsTraking = false)
        {
            return FindAll(AsTraking);
        }

        public async Task<ICollection<int>> GetSessionAttendeesAsync(int sessionId, CancellationToken cancellationToken)
        {
            return await RepositoryContext.Sessions
                    .Where(s => s.Id == sessionId)
                    .Include(s => s.SessionAttendees)
                    .SelectMany(s => s.SessionAttendees.Select(sa => sa.AttendeeId))
                    .ToArrayAsync(cancellationToken);
        }

        public async Task<IEnumerable<Session>> GetSessionByIdsAsync(IReadOnlyList<int> keys)
        {
            return await FindAll()
                         .Where(s => keys.Contains(s.Id))
                         .ToListAsync();
        }

        public async Task<ICollection<int>> GetSessionSpeakersAsync(int sessionId, CancellationToken cancellationToken)
        {
            return await RepositoryContext.Sessions
                    .Where(s => s.Id == sessionId)
                    .Include(s => s.SessionSpeakers)
                    .SelectMany(s => s.SessionSpeakers.Select(ss => ss.SpeakerId))
                    .ToArrayAsync(cancellationToken);
        }

        public void UpdateSession(Session session) => Update(session);
    }
}