
using GrahpQL.Presentation.DataLoader;
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GrahpQL.Presentation.Types
{
    public class TrackType : ObjectType<Track>
    {
        protected override void Configure(IObjectTypeDescriptor<Track> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode(async (context, id) =>
                            {
                                Track track =
                                    await context.DataLoader<TrackByIdDataLoader>().LoadAsync(id, context.RequestAborted);

                                return track;
                            });


            descriptor
                .Field(t => t.Sessions)
                .ResolveWith<TrackResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default))
                .Name("sessions");
        }

        private class TrackResolvers
        {
            public async Task<IEnumerable<Session>> GetSessionsAsync(
                [Parent] Track track,
                IServiceManager service,
                SessionByIdDataLoader sessionById,
                CancellationToken cancellationToken)
            {
                IReadOnlyList<int> sessionIds = (IReadOnlyList<int>)await service.TrackServices.GetTrackSessionsAsync(track.Id, cancellationToken);

                return await sessionById.LoadAsync(sessionIds, cancellationToken);
            }
        }
    }
}