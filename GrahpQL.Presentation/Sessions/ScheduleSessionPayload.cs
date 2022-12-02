
using GrahpQL.Presentation.DataLoader;
using GrahpQL.Presentation.Shared;
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GrahpQL.Presentation.Sessions
{
    public class ScheduleSessionPayload : SessionPayloadBase
    {
        public ScheduleSessionPayload(Session session)
            : base(session)
        {
        }

        public ScheduleSessionPayload(UserError error)
            : base(new[] { error })
        {
        }

        public async Task<Track?> GetTrackAsync(
            TrackByIdDataLoader trackById,
            CancellationToken cancellationToken)
        {
            if (Session is null)
            {
                return null;
            }

            return await trackById.LoadAsync(Session.Id, cancellationToken);
        }

        public async Task<IEnumerable<Speaker>?> GetSpeakersAsync(
            IServiceManager service,
            SpeakerByIdDataLoader speakerById,
            CancellationToken cancellationToken)
        {
            if (Session is null)
            {
                return null;
            }

            var speakerIds = await service.SessionServices.GetSessionSpeakersAsync(Session.Id, cancellationToken);

            return (IEnumerable<Speaker>?)await speakerById.LoadAsync(speakerIds, cancellationToken);
        }

    }
}