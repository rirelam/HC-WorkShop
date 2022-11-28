
using GraphQL.Entities;
using GraphQL.Shared.DTO;

namespace GraphQL.Services.Contracts
{
    public interface ISpeakerServices
    {
        Task<IEnumerable<Speaker>> GetAllSpeakersAsync(bool trackChanges = false);
        Task<IEnumerable<Speaker>> GetSpeakerbyIdsAsync(IReadOnlyList<int> keys);
        Task AddSpeaker(AddSpeakerInputDto speakerInput);
        Task<IReadOnlyDictionary<int, Speaker>> GetSpeakersDictionaryAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken);
        Task<ICollection<int>> GetSessionsIdsAsync(Speaker speaker, CancellationToken cancellationToken);

    }
}