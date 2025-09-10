#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

using mmazur.YnabApiClient.V1.Models.Accounts;
using mmazur.YnabApiClient.V1.Models.Categories;
using mmazur.YnabApiClient.V1.Models.Months;
using mmazur.YnabApiClient.V1.Models.PayeeLocations;
using mmazur.YnabApiClient.V1.Models.Payees;
using mmazur.YnabApiClient.V1.Models.Transactions;

namespace mmazur.YnabApiClient.V1.Models.Budgets;

public sealed record BudgetDetail
{
    [JsonInclude]
    [JsonPropertyName("accounts")]
    private List<Account> _accounts = [];

    [JsonInclude]
    [JsonPropertyName("payees")]
    private List<Payee> _payees = [];

    [JsonInclude]
    [JsonPropertyName("payee_locations")]
    private List<PayeeLocation> _payeeLocations = [];

    [JsonInclude]
    [JsonPropertyName("category_groups")]
    private List<CategoryGroup> _categoryGroups = [];

    [JsonInclude]
    [JsonPropertyName("categories")]
    private List<Category> _categories = [];

    [JsonInclude]
    [JsonPropertyName("months")]
    private List<MonthSummary> _months = [];

    ////[JsonInclude]
    ////[JsonPropertyName("transactions")]
    ////private List<TransactionSummary> _transactions = [];

    ////[JsonInclude]
    ////[JsonPropertyName("subtransactions")]
    ////private List<SubTransaction> _subTransactions = [];

    [JsonInclude]
    [JsonPropertyName("scheduled_transactions")]
    private List<ScheduledTransactionSummary> _scheduledTransactions = [];

    [JsonInclude]
    [JsonPropertyName("scheduled_subtransactions")]
    private List<ScheduledSubTransaction> _scheduledSubTransactions = [];

    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("last_modified_on")]
    public required DateTimeOffset? LastModifiedOn { get; init; }

    [JsonPropertyName("first_month")]
    public required DateOnly? FirstMonth { get; init; }

    [JsonPropertyName("last_month")]
    public required DateOnly? LastMonth { get; init; }

    [JsonPropertyName("date_format")]
    public required DateFormat? DateFormat { get; init; }

    [JsonPropertyName("currency_format")]
    public required CurrencyFormat? CurrencyFormat { get; init; }

    public IReadOnlyList<Account> Accounts => _accounts.AsReadOnly();

    public IReadOnlyList<Payee> Payees => _payees.AsReadOnly();
    public IReadOnlyList<PayeeLocation> PayeeLocations => _payeeLocations.AsReadOnly();

    public IReadOnlyList<CategoryGroup> CategoryGroups => _categoryGroups.AsReadOnly();
    public IReadOnlyList<Category> Categories => _categories.AsReadOnly();

    public IReadOnlyList<MonthSummary> Months => _months.AsReadOnly();

    ////public IReadOnlyList<TransactionSummary> Transactions => _transactions.AsReadOnly();
    ////public IReadOnlyList<Subtransaction> Subtransactions => _subtransactions.AsReadOnly();

    public IReadOnlyList<ScheduledTransactionSummary> ScheduledTransactions => _scheduledTransactions.AsReadOnly();
    public IReadOnlyList<ScheduledSubTransaction> ScheduledSubtransactions => _scheduledSubTransactions.AsReadOnly();
}