using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models;

internal sealed record DataResponse<TData>
{
    [JsonPropertyName("data")]
    public required TData Data { get; init; }
}