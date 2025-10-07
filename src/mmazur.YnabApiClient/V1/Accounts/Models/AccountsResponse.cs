#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Accounts.Models;

public sealed record AccountsResponse
{
    [JsonConstructor]
    private AccountsResponse()
    {
    }

    [JsonInclude]
    [JsonPropertyName("accounts")]
    [JsonRequired]
    private List<Account> _accounts = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    [JsonRequired]
    public required long ServerKnowledge { get; init; }

    [JsonIgnore]
    public IReadOnlyList<Account> Accounts => _accounts.AsReadOnly();
}