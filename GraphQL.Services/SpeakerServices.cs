
using GrahpQL.Contracts;
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GraphQL.Services
{
    public class SpeakerServices : ISpeakerServices
    {
        private readonly IRepositoryManager _repository;

        public SpeakerServices(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Speaker>> GetAllSpeakersAsync(bool trackChanges = false)
        {
            return await _repository.Speaker.GetAllSpeakerAsync();
        }
    }
}