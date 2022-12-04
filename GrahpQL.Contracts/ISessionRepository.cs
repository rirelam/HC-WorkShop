
using GraphQL.Entities;

namespace GrahpQL.Contracts
{
    public interface ISessionRepository
    {
        IQueryable<Session> GetAllSessions(bool AsTraking = false);
        void AddSession(Session session);
        void UpdateSession(Session session);
        IQueryable<Session> FindAsync(int sessionId);
        Task<IEnumerable<Session>> GetSessionByIdsAsync(IReadOnlyList<int> keys);
        Task<ICollection<int>> GetSessionSpeakersAsync(int sessionId, CancellationToken cancellationToken);
        Task<ICollection<int>> GetSessionAttendeesAsync(int sessionId, CancellationToken cancellationToken);
    }
}