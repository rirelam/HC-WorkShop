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
        public async Task<IEnumerable<Session>> GetSessions([Service] IServiceManager service)
        {
            return await service.SessionServices.GetAllSessionsAsync();
        }

        public async Task<Speaker> GetSpeakerAsync(
            int id,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(id, cancellationToken);
            
        public async Task<Session> GetSessionAsync(
            int id,
            SessionByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(id, cancellationToken);
    }
} 