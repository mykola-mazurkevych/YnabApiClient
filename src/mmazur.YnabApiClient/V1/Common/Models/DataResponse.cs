#pragma warning disable CA1812 // Avoid uninstantiated internal classes

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Common.Models;

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