
using GrahpQL.Contracts;
using GraphQL.Entities;
using GraphQL.Services.Contracts;
using GraphQL.Shared.DTO;

namespace GraphQL.Services
{
    public class SpeakerServices : ISpeakerServices
    {
        private readonly IRepositoryManager _repository;

        public SpeakerServices(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task AddSpeaker(AddSpeakerInputDto speakerInput)
        {
            _repository.Speaker.AddSpeaker(speakerInput);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<Speaker>> GetAllSpeakersAsync(bool trackChanges = false)
        {
            return await _repository.Speaker.GetAllSpeakersAsync();
        }

        public async Task<ICollection<int>> GetSessionsIdsAsync(Speaker speaker, CancellationToken cancellationToken)
        {
            return await _repository.Speaker.GetSessionsIdsAsync(speaker.Id, cancellationToken);
        }

        public async Task<IEnumerable<Speaker>> GetSpeakerbyIdsAsync(IReadOnlyList<int> keys)
        {
            return await _repository.Speaker.GetSpeakerbyIdsAsync(keys);
        }

        public async Task<IReadOnlyDictionary<int, Speaker>> GetSpeakersDictionaryAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            return await _repository.Speaker.GetSpeakersDictionaryAsync(keys, cancellationToken);
        }
    }
}