using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

internal sealed class YnabV1TransactionApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, string transactionId, string bearerToken)
    : YnabApiClientBase(httpClientFactory, logger), IYnabV1TransactionApiClient
{
    private readonly Uri _resourceUri = new(baseUri, $"{transactionId}/");

    public Task<TransactionResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<TransactionResponse>(_resourceUri, bearerToken, cancellationToken);

    public Task<TransactionResponse> UpdateAsync(ExistingTransaction transaction, CancellationToken cancellationToken = default) =>
        this.PutAsync<TransactionResponse>(_resourceUri, new PutTransactionWrapper { Transaction = transaction }, bearerToken, cancellationToken);

    public Task<TransactionResponse> DeleteAsync(CancellationToken cancellationToken = default) =>
        this.DeleteAsync<TransactionResponse>(_resourceUri, bearerToken, cancellationToken);
}