
using GrahpQL.Contracts;
using GraphQL.Entities;
using GraphQL.Services.Contracts;

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

        public async Task<IEnumerable<Session>> GetAllSessionsAsync(bool trackChanges = false)
        {
            return await _repository.Session.GetAllSessionsAsync();
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
    }
}