using GraphQL.Entities;
using GraphQL.Shared.DTO;

namespace GrahpQL.Contracts
{
    public interface ISpeakerRepository
    {
        Task<IEnumerable<Speaker>> GetAllSpeakerAsync(bool AsTraking = false);
        void AddSpeaker(AddSpeakerDto speakerDto);
    }
}