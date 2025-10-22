using mmazur.YnabApiClient.V1.Accounts;
using mmazur.YnabApiClient.V1.Budgets.Models;
using mmazur.YnabApiClient.V1.Categories;
using mmazur.YnabApiClient.V1.Months;
using mmazur.YnabApiClient.V1.PayeeLocations;
using mmazur.YnabApiClient.V1.Payees;
using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Budgets;

public interface IYnabV1BudgetApiClient
{
    IYnabV1BudgetSettingsApiClient Settings { get; }

    IYnabV1AccountsApiClient Accounts { get; }

    IYnabV1CategoriesApiClient Categories { get; }

    IYnabV1MonthsApiClient Months { get; }

    IYnabV1PayeeLocationsApiClient PayeeLocations { get; }

    IYnabV1PayeesApiClient Payees { get; }

    IYnabV1ScheduledTransactionsApiClient ScheduledTransactions { get; }

    IYnabV1TransactionsApiClient Transactions { get; }

    /// <summary>
    /// Returns a single budget with all related entities. This resource is effectively a full budget export.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<BudgetDetailResponse?> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a single budget with all related entities. This resource is effectively a full budget export.
    /// </summary>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<BudgetDetailResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default);
}