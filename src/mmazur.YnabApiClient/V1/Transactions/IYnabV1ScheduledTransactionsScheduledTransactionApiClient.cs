namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1ScheduledTransactionsScheduledTransactionApiClient
{
    IYnabV1ScheduledTransactionApiClient this[Guid scheduledTransactionId] { get; }
}