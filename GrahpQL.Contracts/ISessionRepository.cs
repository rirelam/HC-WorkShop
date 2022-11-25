
using GraphQL.Entities;

namespace GrahpQL.Contracts
{
    public interface ISessionRepository
    {
        Task<IReadOnlyDictionary<int, Session>> GetSessionDictionaryAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken);

    }
}