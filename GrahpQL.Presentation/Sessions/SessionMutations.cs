
using GrahpQL.Presentation.Shared;
using GraphQL.Entities;
using GraphQL.Services.Contracts;

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
    }
}