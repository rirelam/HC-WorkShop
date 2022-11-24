
namespace GraphQL.Shared.DTO;

public record AddSpeakerInputDto
{
    public string? Name { get; init; }
    public string? Bio { get; init; }
    public string? WebSite { get; init; }
}
