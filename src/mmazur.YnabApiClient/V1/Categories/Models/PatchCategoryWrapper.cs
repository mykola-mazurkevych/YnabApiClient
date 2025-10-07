using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Categories.Models;

internal sealed record PatchCategoryWrapper
{
    [JsonPropertyName("category")]
    public required SaveCategory Category { get; init; }
}