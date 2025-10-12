namespace mmazur.YnabApiClient.V1.Categories;

public interface IYnabV1CategoryApiClient :
    IYnabV1CategoryGetApiClient,
    IYnabV1CategoryTransactionsApiClient,
    IYnabV1CategoryUpdateApiClient;