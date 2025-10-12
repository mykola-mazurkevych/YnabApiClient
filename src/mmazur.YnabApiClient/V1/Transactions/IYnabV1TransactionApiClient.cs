namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1TransactionApiClient :
    IYnabV1TransactionDeleteApiClient,
    IYnabV1TransactionGetApiClient,
    IYnabV1TransactionUpdateApiClient;