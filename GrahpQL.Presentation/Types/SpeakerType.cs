using GrahpQL.Presentation.DataLoader;
using GraphQL.Entities;
using GraphQL.Services.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace GrahpQL.Presentation.Types
{
    public class SpeakerType : ObjectType<Speaker>
    {
        protected override void Configure(IObjectTypeDescriptor<Speaker> descriptor)
        {
            descriptor
                .Field(t => t.SessionSpeakers)
                .ResolveWith<SpeakerResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default))
                .Name("sessions");
        }

        private sealed class SpeakerResolvers
        {
            public async Task<IEnumerable<Session>> GetSessionsAsync(
                [Parent] Speaker speaker,
                [Service] IServiceManager service,
                SessionByIdDataLoader sessionById,
                CancellationToken cancellationToken)
            {
                IReadOnlyList<int> sessionIds = (IReadOnlyList<int>)await service.SpeakerServices.GetSessionsIdsAsync(speaker, cancellationToken);

                return await sessionById.LoadAsync(sessionIds, cancellationToken);
            }
        }

    }
}