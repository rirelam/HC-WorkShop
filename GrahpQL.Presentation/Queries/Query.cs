using GrahpQL.Presentation.DataLoader;
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GrahpQL.Presentation.Queries
{
    public class Query
    {
        public async Task<IEnumerable<Speaker>> GetSpeakers([Service] IServiceManager service)
        {
            return await service.SpeakerServices.GetAllSpeakersAsync();
        }

        public Task<Speaker> GetSpeakerAsync(
            int id,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);
    }
}