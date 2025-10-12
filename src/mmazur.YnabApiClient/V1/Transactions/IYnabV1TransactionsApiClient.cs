namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1TransactionsApiClient :
    IYnabV1TransactionsCreateApiClient,
    IYnabV1TransactionsGetApiClient,
    IYnabV1TransactionsImportApiClient,
    IYnabV1TransactionsTransactionApiClient,
    IYnabV1TransactionsUpdateApiClient;