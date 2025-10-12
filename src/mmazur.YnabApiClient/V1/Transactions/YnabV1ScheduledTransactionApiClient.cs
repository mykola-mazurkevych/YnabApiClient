using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

internal sealed class YnabV1ScheduledTransactionApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, Guid scheduledTransactionId, string bearerToken) :
    YnabApiClientBase(httpClientFactory, logger),
    IYnabV1ScheduledTransactionApiClient
{
    private readonly Uri _resourceUri = new(baseUri, $"{scheduledTransactionId}/");

    public Task<ScheduledTransactionResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<ScheduledTransactionResponse>(_resourceUri, bearerToken, cancellationToken);

    public Task<ScheduledTransactionResponse> UpdateAsync(SaveScheduledTransaction scheduledTransaction, CancellationToken cancellationToken = default) =>
        this.PutAsync<ScheduledTransactionResponse>(_resourceUri, new PutScheduledTransactionWrapper { ScheduledTransaction = scheduledTransaction }, bearerToken, cancellationToken);

    public Task<ScheduledTransactionResponse> DeleteAsync(CancellationToken cancellationToken = default) =>
        this.DeleteAsync<ScheduledTransactionResponse>(_resourceUri, bearerToken, cancellationToken);
}