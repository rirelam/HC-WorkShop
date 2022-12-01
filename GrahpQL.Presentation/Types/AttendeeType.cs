
using GrahpQL.Presentation.DataLoader;
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GrahpQL.Presentation.Types
{
    public class AttendeeType : ObjectType<Attendee>
    {
        protected override void Configure(IObjectTypeDescriptor<Attendee> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode(async (context, id) =>
                            {
                                Attendee attendee =
                                    await context.DataLoader<AttendeeByIdDataLoader>().LoadAsync(id, context.RequestAborted);

                                return attendee;
                            });

            descriptor
                .Field(t => t.SessionsAttendees)
                .ResolveWith<AttendeeResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default))
                .Name("sessions");
        }

        private class AttendeeResolvers
        {
            public async Task<IEnumerable<Session>> GetSessionsAsync(
                [Parent] Attendee attendee,
                IServiceManager service,
                SessionByIdDataLoader sessionById,
                CancellationToken cancellationToken)
            {
                IReadOnlyList<int> sessionIds = (IReadOnlyList<int>)await service.AttendeeServices.GetAttendeeSessionsAsync(attendee.Id, cancellationToken);

                return await sessionById.LoadAsync(sessionIds, cancellationToken);
            }
        }
    }
}