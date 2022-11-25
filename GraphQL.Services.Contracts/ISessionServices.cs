using GraphQL.Entities;

namespace GraphQL.Services.Contracts
{
    public interface ISessionServices
    {
        Task<IReadOnlyDictionary<int, Session>> GetSessionDictionaryAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken);
    }
}