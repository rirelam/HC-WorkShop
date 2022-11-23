
namespace GraphQL.Shared.DTO;

public record AddSpeakerDto
{
    public string Name { get; init; }
    public string Bio { get; init; }
    public string WebSite { get; init; }
}
