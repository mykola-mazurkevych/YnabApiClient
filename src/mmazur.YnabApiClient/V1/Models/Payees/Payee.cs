using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Payees;

public sealed record Payee
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// If a transfer payee, the account_id to which this payee transfers to
    /// </summary>
    [JsonPropertyName("transfer_account_id")]
    public required string? TransferAccountId { get; init; }

    /// <summary>
    /// Whether the payee has been deleted. Deleted payees will only be included in delta requests
    /// </summary>
    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }
}