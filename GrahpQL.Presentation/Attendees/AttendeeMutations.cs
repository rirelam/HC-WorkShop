using GrahpQL.Presentation.Shared;
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GrahpQL.Presentation.Attendees
{
    [ExtendObjectType("Mutation")]
    public class AttendeeMutations
    {
        public async Task<RegisterAttendeePayload> RegisterAttendeeAsync(
            RegisterAttendeeInput input,
            IServiceManager service,
            CancellationToken cancellationToken)
        {
            var attendee = new Attendee
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                UserName = input.UserName,
                EmailAddress = input.EmailAddress
            };

           await service.AttendeeServices.Add(attendee);

            return new RegisterAttendeePayload(attendee);
        }

        public async Task<CheckInAttendeePayload> CheckInAttendeeAsync(
            CheckInAttendeeInput input,
            IServiceManager service,
            CancellationToken cancellationToken)
        {
            Attendee? attendee = await service.AttendeeServices.GetAttendeeByIdAsync(input.AttendeeId, cancellationToken);

            if (attendee is null)
            {
                return new CheckInAttendeePayload(
                    new UserError("Attendee not found.", "ATTENDEE_NOT_FOUND"));
            }

            attendee.SessionsAttendees.Add(
                new SessionAttendee
                {
                    SessionId = input.SessionId
                });

            await service.AttendeeServices.UpdateAttendee(attendee, cancellationToken);

            return new CheckInAttendeePayload(attendee, input.SessionId);
        }
    }
}