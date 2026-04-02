using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Accounts.Models;

public sealed record AccountsResponse
{
    [JsonConstructor]
    private AccountsResponse()
    {
    }

    [JsonPropertyName("accounts")]
    [JsonRequired]
    public IReadOnlyList<Account> Accounts { get; init; } = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    [JsonRequired]
    public required long ServerKnowledge { get; init; }
}