using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

internal sealed class YnabV1ScheduledTransactionsApiClient(HttpClient httpClient, Uri parentUri, ILogger? logger) :
    YnabApiClientBase(httpClient, logger),
    IYnabV1ScheduledTransactionsApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = parentUri.AppendPath("scheduled_transactions/");

    public IYnabV1ScheduledTransactionApiClient this[Guid scheduledTransactionId] =>
        new YnabV1ScheduledTransactionApiClient(_httpClient, _resourcesUri, scheduledTransactionId, _logger);

    public Task<ScheduledTransactionsResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<ScheduledTransactionsResponse>(_resourcesUri, cancellationToken);

    public Task<ScheduledTransactionsResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        GetAsync<ScheduledTransactionsResponse>(_resourcesUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, cancellationToken);

    public Task<ScheduledTransactionResponse> CreateAsync(SaveScheduledTransaction scheduledTransaction, CancellationToken cancellationToken = default) =>
        PostAsync<ScheduledTransactionResponse>(_resourcesUri, new PostScheduledTransactionWrapper { ScheduledTransaction = scheduledTransaction }, cancellationToken);
}