namespace mmazur.YnabApiClient.V1.Payees;

public interface IYnabV1PayeeApiClient :
    IYnabV1PayeeGetApiClient,
    IYnabV1PayeePayeeLocationsApiClient,
    IYnabV1PayeeTransactionsApiClient,
    IYnabV1PayeeUpdateApiClient;