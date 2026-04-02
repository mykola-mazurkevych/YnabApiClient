using System.Text.Json.Serialization;

using mmazur.YnabApiClient.V1.Accounts.Models;
using mmazur.YnabApiClient.V1.Categories.Models;
using mmazur.YnabApiClient.V1.Months.Models;
using mmazur.YnabApiClient.V1.PayeeLocations.Models;
using mmazur.YnabApiClient.V1.Payees.Models;
using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Budgets.Models;

public sealed record BudgetDetail
{
    [JsonPropertyName("accounts")]
    public IReadOnlyList<Account> Accounts { get; init; } = [];

    [JsonPropertyName("payees")]
    public IReadOnlyList<Payee> Payees { get; init; } = [];

    [JsonPropertyName("payee_locations")]
    public IReadOnlyList<PayeeLocation> PayeeLocations { get; init; } = [];

    [JsonPropertyName("category_groups")]
    public IReadOnlyList<CategoryGroup> CategoryGroups { get; init; } = [];

    [JsonPropertyName("categories")]
    public IReadOnlyList<Category> Categories { get; init; } = [];

    [JsonPropertyName("months")]
    public IReadOnlyList<MonthDetail> Months { get; init; } = [];

    [JsonPropertyName("transactions")]
    public IReadOnlyList<TransactionSummary> Transactions { get; init; } = [];

    [JsonPropertyName("subtransactions")]
    public IReadOnlyList<SubTransaction> SubTransactions { get; init; } = [];

    [JsonPropertyName("scheduled_transactions")]
    public IReadOnlyList<ScheduledTransactionSummary> ScheduledTransactions { get; init; } = [];

    [JsonPropertyName("scheduled_subtransactions")]
    public IReadOnlyList<ScheduledSubTransaction> ScheduledSubTransactions { get; init; } = [];

    [JsonPropertyName("id")]
    [JsonRequired]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    [JsonRequired]
    public required string Name { get; init; }

    [JsonPropertyName("last_modified_on")]
    public DateTimeOffset? LastModifiedOn { get; init; }

    [JsonPropertyName("first_month")]
    public DateOnly? FirstMonth { get; init; }

    [JsonPropertyName("last_month")]
    public DateOnly? LastMonth { get; init; }

    [JsonPropertyName("date_format")]
    public DateFormat? DateFormat { get; init; }

    [JsonPropertyName("currency_format")]
    public CurrencyFormat? CurrencyFormat { get; init; }

}