namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1TransactionsApiClient
    : IYnabV1TransactionsGetApiClient, IYnabV1TransactionsCreateApiClient, IYnabV1TransactionsUpdateApiClient, IYnabV1TransactionsImportApiClient
{
    IYnabV1TransactionApiClient this[string transactionsId] { get; }
}