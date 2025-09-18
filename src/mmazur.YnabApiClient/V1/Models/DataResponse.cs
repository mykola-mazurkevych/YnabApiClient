using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models;

internal sealed record DataResponse<TData>
    where TData : class
{
    [JsonConstructor]
    private DataResponse()
    {
    }

    [JsonPropertyName("data")]
    [JsonRequired]
    public required TData? Data { get; init; }
}