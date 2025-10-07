#pragma warning disable CA1043 // Use integral or string argument for indexers

namespace mmazur.YnabApiClient.V1.Months;

public interface IYnabV1MonthsApiClient
    : IYnabV1MonthsGetApiClient
{
    IYnabV1MonthApiClient this[DateOnly month] { get; }
}