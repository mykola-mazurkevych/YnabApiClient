using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

internal sealed class YnabV1ScheduledTransactionApiClient(HttpClient httpClient, Uri parentUri, Guid scheduledTransactionId, ILogger? logger) :
    YnabApiClientBase(httpClient, logger),
    IYnabV1ScheduledTransactionApiClient
{
    private readonly Uri _resourceUri = parentUri.AppendPath($"{scheduledTransactionId}/");

    public Task<ScheduledTransactionResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<ScheduledTransactionResponse>(_resourceUri, cancellationToken);

    public Task<ScheduledTransactionResponse> UpdateAsync(SaveScheduledTransaction scheduledTransaction, CancellationToken cancellationToken = default) =>
        PutAsync<ScheduledTransactionResponse>(_resourceUri, new PutScheduledTransactionWrapper { ScheduledTransaction = scheduledTransaction }, cancellationToken);

    public Task<ScheduledTransactionResponse> DeleteAsync(CancellationToken cancellationToken = default) =>
        DeleteAsync<ScheduledTransactionResponse>(_resourceUri, cancellationToken);
}