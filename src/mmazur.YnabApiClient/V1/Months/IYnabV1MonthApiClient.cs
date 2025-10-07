using mmazur.YnabApiClient.V1.Categories;
using mmazur.YnabApiClient.V1.Months.Models;
using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Months;

public interface IYnabV1MonthApiClient
{
    IYnabV1CategoriesApiClient Categories { get; } // TODO: check if a new MonthCategories client needed
    IYnabV1TransactionsApiClient Transactions { get; }

    /// <summary>
    /// Single budget month
    /// Returns a single budget month
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MonthDetailResponse?> GetAsync(CancellationToken cancellationToken = default);
}