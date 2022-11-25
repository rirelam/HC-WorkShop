
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

        public async Task<IReadOnlyDictionary<int, Session>> GetSessionDictionaryAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            return await _repository.Session.GetSessionDictionaryAsync(keys, cancellationToken);
        }
    }
}