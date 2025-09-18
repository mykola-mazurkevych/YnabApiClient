using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Categories;

public sealed record SaveCategoryResponse
{
    [JsonConstructor]
    private SaveCategoryResponse()
    {
    }

    [JsonPropertyName("category")]
    [JsonRequired]
    public required Category Category { get; init; }

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    [JsonRequired]
    public required long ServerKnowledge { get; init; }
}