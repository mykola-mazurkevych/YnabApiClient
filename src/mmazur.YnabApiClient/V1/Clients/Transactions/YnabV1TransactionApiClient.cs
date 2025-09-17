using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.Transactions;
using mmazur.YnabApiClient.V1.Models.Transactions;

namespace mmazur.YnabApiClient.V1.Clients.Transactions;

internal sealed class YnabV1TransactionApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, string transactionId, string bearerToken)
    : YnabApiClientBase(httpClientFactory), IYnabV1TransactionApiClient
{
    private readonly Uri _resourceUri = new(baseUri, $"{transactionId}/");

    public Task<TransactionResponse> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<TransactionResponse>(_resourceUri, null, bearerToken, cancellationToken);

    public Task<TransactionResponse> UpdateAsync(ExistingTransaction transaction, CancellationToken cancellationToken = default) =>
        this.PutAsync<TransactionResponse>(_resourceUri, new PutTransactionWrapper { Transaction = transaction }, bearerToken, cancellationToken);

    public Task<TransactionResponse> DeleteAsync(CancellationToken cancellationToken = default) =>
        this.DeleteAsync<TransactionResponse>(_resourceUri, bearerToken, cancellationToken);
}