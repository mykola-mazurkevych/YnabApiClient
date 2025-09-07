using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Payees;

public sealed record Payee
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("transfer_account_id")]
    public required string? TransferAccountId { get; init; }

    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }
}