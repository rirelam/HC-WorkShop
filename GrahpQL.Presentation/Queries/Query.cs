using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GrahpQL.Presentation.Queries
{
    public class Query
    {
        public async Task<IEnumerable<Speaker>> GetSpeaker([Service] IServiceManager service)
        {
            return await service.SpeakerServices.GetAllSpeakersAsync();
        }
    }
}