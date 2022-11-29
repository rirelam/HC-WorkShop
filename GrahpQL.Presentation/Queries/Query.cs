using GrahpQL.Presentation.DataLoader;
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GrahpQL.Presentation.Queries
{
    public class Query
    {
        public async Task<IEnumerable<Speaker>> GetSpeakers(IServiceManager service)
        {
            return await service.SpeakerServices.GetAllSpeakersAsync();
        }
        public async Task<IEnumerable<Session>> GetSessions(IServiceManager service)
        {
            return await service.SessionServices.GetAllSessionsAsync();
        }

        public async Task<Speaker> GetSpeakerAsync(
            [ID(nameof(Speaker))] int id,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(id, cancellationToken);
            
        public async Task<Session> GetSessionAsync(
            [ID(nameof(Session))] int id,
            SessionByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(id, cancellationToken);
    }
} 