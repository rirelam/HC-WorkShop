
using GraphQL.Entities;

namespace GraphQL.Services.Contracts
{
    public interface ISpeakerServices
    {
       Task<IEnumerable<Speaker>> GetAllSpeakersAsync(bool trackChanges = false); 
    }
}