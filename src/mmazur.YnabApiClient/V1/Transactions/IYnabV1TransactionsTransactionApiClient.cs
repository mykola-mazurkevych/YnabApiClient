namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1TransactionsTransactionApiClient
{
    IYnabV1TransactionApiClient this[string transactionsId] { get; }
}