
using GrahpQL.Presentation.Shared;
using GraphQL.Entities;
using GraphQL.Services.Contracts;
using HotChocolate.Subscriptions;

namespace GrahpQL.Presentation.Sessions
{
    [ExtendObjectType("Mutation")]
    public class SessionMutations
    {
        public async Task<AddSessionPayload> AddSessionAsync(
            AddSessionInput input,
            IServiceManager service,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(input.Title))
            {
                return new AddSessionPayload(
                    new UserError("The title cannot be empty.", "TITLE_EMPTY"));
            }

            if (input.SpeakerIds.Count == 0)
            {
                return new AddSessionPayload(
                    new UserError("No speaker assigned.", "NO_SPEAKER"));
            }

            var session = new Session
            {
                Title = input.Title,
                Abstract = input.Abstract,
            };

            foreach (int speakerId in input.SpeakerIds)
            {
                session.SessionSpeakers.Add(new SessionSpeaker
                {
                    SpeakerId = speakerId
                });
            }

            await service.SessionServices.AddSession(session);

            return new AddSessionPayload(session);
        }

        public async Task<ScheduleSessionPayload> ScheduleSessionAsync(
                    ScheduleSessionInput input,
                    IServiceManager service,
                    [Service] ITopicEventSender eventSender)
        {
            if (input.EndTime < input.StartTime)
            {
                return new ScheduleSessionPayload(
                    new UserError("endTime has to be larger than startTime.", "END_TIME_INVALID"));
            }

            Session? session = await service.SessionServices.FindAsync(input.SessionId);

            if (session is null)
            {
                return new ScheduleSessionPayload(
                    new UserError("Session not found.", "SESSION_NOT_FOUND"));
            }

            session.TrackId = input.TrackId;
            session.StartTime = input.StartTime;
            session.EndTime = input.EndTime;

            await service.SessionServices.UpdateSessionAsync(session);

            await eventSender.SendAsync(
                        nameof(SessionSubscriptions.OnSessionScheduledAsync),
                        session.Id);

            return new ScheduleSessionPayload(session);
        }
    }
}