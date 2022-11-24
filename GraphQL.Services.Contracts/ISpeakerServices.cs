
using GraphQL.Entities;
using GraphQL.Shared.DTO;

namespace GraphQL.Services.Contracts
{
    public interface ISpeakerServices
    {
        Task<IEnumerable<Speaker>> GetAllSpeakersAsync(bool trackChanges = false);
        Task AddSpeaker(AddSpeakerInputDto speakerInput);
    }
}