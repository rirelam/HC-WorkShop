
using GrahpQL.Contracts;
using GraphQL.Entities;
using GraphQL.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Services
{
    public class SessionServices : ISessionServices
    {
        private readonly IRepositoryManager _repository;

        public SessionServices(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task AddSession(Session session)
        {
            _repository.Session.AddSession(session);
            await _repository.SaveAsync();
        }

        public async Task<Session?> FindAsync(int sessionId)
        {
            return await _repository.Session.FindAsync(sessionId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Session>> GetAllSessionsAsync(CancellationToken cancellationToken, bool trackChanges = false)
        {
            return await _repository.Session.GetAllSessionsAsync(cancellationToken);
        }

        public async Task<ICollection<int>> GetSessionAttendeesAsync(int sessionId, CancellationToken cancellationToken)
        {
            return await _repository.Session.GetSessionAttendeesAsync(sessionId, cancellationToken);
        }

        public async Task<IEnumerable<Session>> GetSessionByIdsAsync(IReadOnlyList<int> keys)
        {
            return await _repository.Session.GetSessionByIdsAsync(keys);
        }

        public async Task<ICollection<int>> GetSessionSpeakersAsync(int sessionId, CancellationToken cancellationToken)
        {
            return await _repository.Session.GetSessionSpeakersAsync(sessionId, cancellationToken);
        }

        public async Task UpdateSessionAsync(Session session)
        {
            _repository.Session.UpdateSession(session);
            await _repository.SaveAsync();
        }
    }
}