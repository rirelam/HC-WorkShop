
using GraphQL.Entities;

namespace GrahpQL.Presentation.Attendees;

public record CheckInAttendeeInput(
    [ID(nameof(Session))]
    int SessionId,
    [ID(nameof(Attendee))]
    int AttendeeId);

