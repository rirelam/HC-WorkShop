using GrahpQL.Presentation.Shared;
using GraphQL.Entities;

namespace GrahpQL.Presentation.Attendees
{
    public class RegisterAttendeePayload : AttendeePayloadBase
    {
        public RegisterAttendeePayload(Attendee attendee) : base(attendee)
        {
        }
        public RegisterAttendeePayload(UserError error) : base(new[] { error })
        {
        }
    }
}