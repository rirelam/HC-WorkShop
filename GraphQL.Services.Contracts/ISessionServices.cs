using GraphQL.Entities;

namespace GraphQL.Services.Contracts
{
    public interface ISessionServices
    {
        Task<IEnumerable<Session>> GetAllSessionsAsync(bool trackChanges = false);
        Task AddSession(Session session);

        Task<IEnumerable<Session>> GetSessionByIdsAsync(IReadOnlyList<int> keys);
        Task<ICollection<int>> GetSessionSpeakersAsync(int sessionId, CancellationToken cancellationToken);
        Task<ICollection<int>> GetSessionAttendeesAsync(int sessionId, CancellationToken cancellationToken);
    }
}