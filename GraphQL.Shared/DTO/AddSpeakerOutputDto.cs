
using System.Runtime.CompilerServices;
using GraphQL.Entities;

namespace GraphQL.Shared.DTO;

public record AddSpeakerOutputDto
{
    public string? Name { get; init; }
    public string? Bio { get; init; }
    public string? Website { get; init; }

}
