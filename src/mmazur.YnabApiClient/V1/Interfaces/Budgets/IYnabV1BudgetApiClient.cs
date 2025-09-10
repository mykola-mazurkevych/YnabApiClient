using mmazur.YnabApiClient.V1.Interfaces.Accounts;
using mmazur.YnabApiClient.V1.Interfaces.Categories;
using mmazur.YnabApiClient.V1.Interfaces.Months;
using mmazur.YnabApiClient.V1.Interfaces.PayeeLocations;
using mmazur.YnabApiClient.V1.Interfaces.Payees;
using mmazur.YnabApiClient.V1.Interfaces.Transactions;
using mmazur.YnabApiClient.V1.Models.Budgets;

namespace mmazur.YnabApiClient.V1.Interfaces.Budgets;

public interface IYnabV1BudgetApiClient
{
    IYnabV1AccountsApiClient Accounts { get; }

    IYnabV1CategoriesApiClient Categories { get; }

    IYnabV1MonthsApiClient Months { get; }

    IYnabV1PayeesApiClient Payees { get; }
    IYnabV1PayeeLocationsApiClient PayeeLocations { get; }

    IYnabV1ScheduledTransactionsApiClient ScheduledTransactions { get; }

    IYnabV1BudgetSettingsApiClient Settings { get; }

    /// <summary>
    /// Returns a single budget with all related entities. This resource is effectively a full budget export.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<BudgetDetailResponse> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a single budget with all related entities. This resource is effectively a full budget export.
    /// </summary>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<BudgetDetailResponse> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default);
}