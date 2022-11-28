using GraphQL.Entities;
using GraphQL.Shared.DTO;

namespace GrahpQL.Contracts
{
    public interface ISpeakerRepository
    {
        Task<IEnumerable<Speaker>> GetAllSpeakersAsync(bool AsTraking = false);
        Task<IReadOnlyDictionary<int, Speaker>> GetSpeakersDictionaryAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken);
        Task<ICollection<int>> GetSessionsIdsAsync(int speakerId, CancellationToken cancellationToken);
        Task<IEnumerable<Speaker>> GetSpeakerbyIdsAsync(IReadOnlyList<int> keys);
        void AddSpeaker(AddSpeakerInputDto speakerDto);
    }
}