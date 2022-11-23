using GraphQL.Entities;

namespace GrahpQL.Contracts
{
    public interface ISpeakerRepository
    {
        Task<IEnumerable<Speaker>> GetAllSpeakerAsync(bool AsTraking = false);
    }
}