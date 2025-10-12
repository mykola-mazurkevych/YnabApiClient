namespace mmazur.YnabApiClient.V1.Months;

public interface IYnabV1MonthsMonthApiClient
{
    IYnabV1MonthApiClient this[DateOnly month] { get; }
}