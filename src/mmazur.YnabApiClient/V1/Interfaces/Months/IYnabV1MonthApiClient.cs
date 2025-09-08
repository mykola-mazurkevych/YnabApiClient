using mmazur.YnabApiClient.V1.Interfaces.Categories;
using mmazur.YnabApiClient.V1.Models.Months;

namespace mmazur.YnabApiClient.V1.Interfaces.Months;

public interface IYnabV1MonthApiClient
{
    IYnabV1CategoriesApiClient Categories { get; } // TODO: check if a new MonthCategories client needed

    /// <summary>
    /// Single budget month
    /// Returns a single budget month
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MonthWithCategoriesResponse> GetAsync(CancellationToken cancellationToken = default);
}