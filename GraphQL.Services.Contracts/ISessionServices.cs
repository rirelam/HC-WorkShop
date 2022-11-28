using GraphQL.Entities;

namespace GraphQL.Services.Contracts
{
    public interface ISessionServices
    {
        Task<IEnumerable<Session>> GetAllSessionsAsync(bool trackChanges = false);

        Task<IEnumerable<Session>> GetSessionByIdsAsync(IReadOnlyList<int> keys);
    }
}