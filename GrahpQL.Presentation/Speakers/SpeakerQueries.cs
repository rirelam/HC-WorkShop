using GrahpQL.Presentation.DataLoader;
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GrahpQL.Presentation.Speakers
{
    [ExtendObjectType("Query")]
    public class SpeakerQueries
    {
        [UsePaging]
        public IQueryable<Speaker> GetSpeaker(IServiceManager service)
        {
            return service.SpeakerServices.GetAllSpeakers();
        }

        public async Task<Speaker> GetSpeakerByIdAsync(
            [ID(nameof(Speaker))] int id,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Speaker>> GetSpeakersByIdAsync(
            [ID(nameof(Speaker))] int[] ids,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(ids, cancellationToken);

    }
}