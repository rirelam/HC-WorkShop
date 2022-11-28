
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

        public async Task<IEnumerable<Session>> GetAllSessionsAsync(bool trackChanges = false)
        {
            return await _repository.Session.GetAllSessionsAsync();
        }

        public async Task<IEnumerable<Session>> GetSessionByIdsAsync(IReadOnlyList<int> keys)
        {
            return await _repository.Session.GetSessionByIdsAsync(keys);
        }

    }
}