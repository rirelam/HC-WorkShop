
namespace GrahpQL.Presentation.Speakers;

public record AddSpeakerInput
{
    public string? Name { get; init; }
    public string? Bio { get; init; }
    public string? WebSite { get; init; }
}
