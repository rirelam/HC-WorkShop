
using GraphQL.Entities;

namespace GrahpQL.Presentation.Tracks;

public record RenameTrackInput([ID(nameof(Track))] int Id, string Name);
