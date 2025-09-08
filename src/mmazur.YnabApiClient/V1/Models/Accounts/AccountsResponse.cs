#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Accounts;

public sealed record AccountsResponse
{
    [JsonInclude]
    [JsonPropertyName("accounts")]
    private List<Account> _accounts = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    public long ServerKnowledge { get; init; }

    public IReadOnlyList<Account> Accounts => _accounts.AsReadOnly();
}