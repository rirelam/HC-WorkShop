
using GraphQL.Entities;

namespace GrahpQL.Presentation.Sessions;

public record AddSessionInput(
        string Title,
        string? Abstract,
        [ID(nameof(Speaker))]
        IReadOnlyList<int> SpeakerIds);