using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.Transactions;
using mmazur.YnabApiClient.V1.Models.Transactions;

namespace mmazur.YnabApiClient.V1.Clients.Transactions;

internal sealed class YnabV1ScheduledTransactionApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, Guid scheduledTransactionId, string bearerToken)
    : YnabApiClientBase(httpClientFactory), IYnabV1ScheduledTransactionApiClient
{
    private readonly Uri _resourceUri = new(baseUri, $"{scheduledTransactionId}/");

    public Task<ScheduledTransactionResponse> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<ScheduledTransactionResponse>(_resourceUri, null, bearerToken, cancellationToken);

    public Task<ScheduledTransactionResponse> UpdateAsync(SaveScheduledTransaction scheduledTransaction, CancellationToken cancellationToken = default) =>
        this.PatchAsync<ScheduledTransactionResponse>(_resourceUri, new PutScheduledTransactionWrapper { ScheduledTransaction = scheduledTransaction }, bearerToken, cancellationToken);

    public Task<ScheduledTransactionResponse> DeleteAsync(CancellationToken cancellationToken = default) =>
        this.DeleteAsync<ScheduledTransactionResponse>(_resourceUri, bearerToken, cancellationToken);
}