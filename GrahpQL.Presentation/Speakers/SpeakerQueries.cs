using GrahpQL.Presentation.DataLoader;
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GrahpQL.Presentation.Speakers
{
    [ExtendObjectType("Query")]
    public class SpeakerQueries
    {
        public async Task<IEnumerable<Speaker>> GetSpeakers(IServiceManager service)
        {
            return await service.SpeakerServices.GetAllSpeakersAsync();
        }

        public async Task<Speaker> GetSpeakerAsync(
            [ID(nameof(Speaker))] int id,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(id, cancellationToken);

    }
}