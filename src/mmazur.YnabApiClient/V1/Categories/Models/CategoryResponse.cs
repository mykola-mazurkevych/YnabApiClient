using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Categories.Models;

public sealed record CategoryResponse
{
    [JsonConstructor]
    private CategoryResponse()
    {
    }

    [JsonPropertyName("category")]
    [JsonRequired]
    public required Category Category { get; init; }
}