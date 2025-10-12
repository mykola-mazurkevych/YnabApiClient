using mmazur.YnabApiClient.V1.Months;

namespace mmazur.YnabApiClient.V1.Budgets;

public interface IYnabV1BudgetMonthsApiClient
{
    IYnabV1MonthsApiClient Months { get; }
}