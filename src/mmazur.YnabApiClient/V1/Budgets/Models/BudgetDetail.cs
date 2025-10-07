#pragma warning disable IDE0044 // Add readonly modifier

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
    private List<MonthDetail> _months = [];

    [JsonInclude]
    [JsonPropertyName("transactions")]
    private List<TransactionSummary> _transactions = [];

    [JsonInclude]
    [JsonPropertyName("subtransactions")]
    private List<SubTransaction> _subTransactions = [];

    [JsonInclude]
    [JsonPropertyName("scheduled_transactions")]
    private List<ScheduledTransactionSummary> _scheduledTransactions = [];

    [JsonInclude]
    [JsonPropertyName("scheduled_subtransactions")]
    private List<ScheduledSubTransaction> _scheduledSubTransactions = [];

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

    [JsonIgnore]
    public IReadOnlyList<Account> Accounts => _accounts.AsReadOnly();

    [JsonIgnore]
    public IReadOnlyList<Payee> Payees => _payees.AsReadOnly();

    [JsonIgnore]
    public IReadOnlyList<PayeeLocation> PayeeLocations => _payeeLocations.AsReadOnly();

    [JsonIgnore]
    public IReadOnlyList<CategoryGroup> CategoryGroups => _categoryGroups.AsReadOnly();

    [JsonIgnore]
    public IReadOnlyList<Category> Categories => _categories.AsReadOnly();

    [JsonIgnore]
    public IReadOnlyList<MonthDetail> Months => _months.AsReadOnly();

    [JsonIgnore]
    public IReadOnlyList<TransactionSummary> Transactions => _transactions.AsReadOnly();

    [JsonIgnore]
    public IReadOnlyList<SubTransaction> SubTransactions => _subTransactions.AsReadOnly();

    [JsonIgnore]
    public IReadOnlyList<ScheduledTransactionSummary> ScheduledTransactions => _scheduledTransactions.AsReadOnly();

    [JsonIgnore]
    public IReadOnlyList<ScheduledSubTransaction> ScheduledSubTransactions => _scheduledSubTransactions.AsReadOnly();
}