using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Categories.Models;

public sealed record CategoryGroupWithCategories
{
    /// <summary>
    /// Category group categories. Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).
    /// </summary>
    [JsonPropertyName("categories")]
    [JsonRequired]
    public IReadOnlyList<Category> Categories { get; init; } = [];

    [JsonPropertyName("id")]
    [JsonRequired]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    [JsonRequired]
    public required string Name { get; init; }

    /// <summary>
    /// Whether the category group is hidden
    /// </summary>
    [JsonPropertyName("hidden")]
    [JsonRequired]
    public required bool Hidden { get; init; }

    /// <summary>
    /// Whether the category group has been deleted. Deleted category groups will only be included in delta requests.
    /// </summary>
    [JsonPropertyName("deleted")]
    [JsonRequired]
    public required bool Deleted { get; init; }
}