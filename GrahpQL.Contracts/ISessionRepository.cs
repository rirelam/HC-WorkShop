
using GraphQL.Entities;

namespace GrahpQL.Contracts
{
    public interface ISessionRepository
    {
        Task<IEnumerable<Session>> GetAllSessionsAsync(bool AsTraking = false);

        Task<IEnumerable<Session>> GetSessionByIdsAsync(IReadOnlyList<int> keys);
    }
}