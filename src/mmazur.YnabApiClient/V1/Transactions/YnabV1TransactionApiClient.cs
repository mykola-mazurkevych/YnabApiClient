using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

internal sealed class YnabV1TransactionApiClient(HttpClient httpClient, Uri parentUri, string transactionId, ILogger? logger) :
    YnabApiClientBase(httpClient, logger),
    IYnabV1TransactionApiClient
{
    private readonly Uri _resourceUri = parentUri.AppendPath($"{transactionId}/");

    public Task<TransactionResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<TransactionResponse>(_resourceUri, cancellationToken);

    public Task<TransactionResponse> UpdateAsync(ExistingTransaction transaction, CancellationToken cancellationToken = default) =>
        PutAsync<TransactionResponse>(_resourceUri, new PutTransactionWrapper { Transaction = transaction }, cancellationToken);

    public Task<TransactionResponse> DeleteAsync(CancellationToken cancellationToken = default) =>
        DeleteAsync<TransactionResponse>(_resourceUri, cancellationToken);
}