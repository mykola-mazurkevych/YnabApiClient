#pragma warning disable CA1043 // Use integral or string argument for indexers

namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1ScheduledTransactionsApiClient
    : IYnabV1ScheduledTransactionsGetApiClient, IYnabV1ScheduledTransactionsCreateApiClient
{
    IYnabV1ScheduledTransactionApiClient this[Guid scheduledTransactionId] { get; }
}