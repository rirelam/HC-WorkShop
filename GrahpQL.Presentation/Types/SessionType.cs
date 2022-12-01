
using GrahpQL.Presentation.DataLoader;
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GrahpQL.Presentation.Types
{
    public class SessionType : ObjectType<Session>
    {
        protected override void Configure(IObjectTypeDescriptor<Session> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode(async (context, id) =>
                            {
                                Session session =
                                    await context.DataLoader<SessionByIdDataLoader>().LoadAsync(id, context.RequestAborted);

                                return session;
                            });

            descriptor
                            .Field(t => t.SessionSpeakers)
                            .ResolveWith<SessionResolvers>(t => t.GetSpeakersAsync(default!, default!, default!, default))
                            .Name("speakers");

            descriptor
                .Field(t => t.SessionAttendees)
                .ResolveWith<SessionResolvers>(t => t.GetAttendeesAsync(default!, default!, default!, default))
                .Name("attendees");

            descriptor
                .Field(t => t.Track)
                .ResolveWith<SessionResolvers>(t => t.GetTrackAsync(default!, default!, default));

            descriptor
                .Field(t => t.TrackId)
                .ID(nameof(Track));
        }

        private class SessionResolvers
        {
            public async Task<IEnumerable<Speaker>> GetSpeakersAsync(
                [Parent] Session session,
                IServiceManager service,
                SpeakerByIdDataLoader speakerById,
                CancellationToken cancellationToken)
            {
                IReadOnlyList<int> speakerIds = (IReadOnlyList<int>)await service.SessionServices.GetSessionSpeakersAsync(session.Id, cancellationToken);

                return await speakerById.LoadAsync(speakerIds, cancellationToken);
            }

            public async Task<IEnumerable<Attendee>> GetAttendeesAsync(
                [Parent] Session session,
                IServiceManager service,
                AttendeeByIdDataLoader attendeeById,
                CancellationToken cancellationToken)
            {
                IReadOnlyList<int> attendeeIds = (IReadOnlyList<int>)await service.SessionServices.GetSessionAttendeesAsync(session.Id, cancellationToken);

                return await attendeeById.LoadAsync(attendeeIds, cancellationToken);
            }

            public async Task<Track?> GetTrackAsync(
                [Parent] Session session,
                TrackByIdDataLoader trackById,
                CancellationToken cancellationToken)
            {
                if (session.TrackId is null)
                {
                    return null;
                }

                return await trackById.LoadAsync(session.TrackId.Value, cancellationToken);
            }
        }
    }
}