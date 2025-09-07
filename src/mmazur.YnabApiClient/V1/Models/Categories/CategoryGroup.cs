#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Categories;

public sealed record CategoryGroup
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("hidden")]
    public required bool Hidden { get; init; }

    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }
}