#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Categories;

public sealed record CategoryGroupWithCategories
{
    /// <summary>
    /// Category group categories. Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("categories")]
    private List<Category> _categories = [];

    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Whether the category group is hidden
    /// </summary>
    [JsonPropertyName("hidden")]
    public required bool Hidden { get; init; }

    /// <summary>
    /// Whether the category group has been deleted. Deleted category groups will only be included in delta requests.
    /// </summary>
    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }

    public IReadOnlyList<Category> Categories => _categories.AsReadOnly();
}