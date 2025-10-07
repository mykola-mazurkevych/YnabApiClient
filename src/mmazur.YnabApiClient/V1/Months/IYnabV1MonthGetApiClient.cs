using mmazur.YnabApiClient.V1.Months.Models;

namespace mmazur.YnabApiClient.V1.Months;

public interface IYnabV1MonthGetApiClient
{
    /// <summary>
    /// Single budget month
    /// Returns a single budget month
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MonthDetailResponse?> GetAsync(CancellationToken cancellationToken = default);
}