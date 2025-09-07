#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Accounts;

public sealed record AccountsResponse
{
    [JsonInclude]
    [JsonPropertyName("accounts")]
    private List<Account> _accounts = [];

    public IReadOnlyList<Account> Accounts => _accounts.AsReadOnly();

    [JsonPropertyName("server_knowledge")]
    public long ServerKnowledge { get; init; }
}