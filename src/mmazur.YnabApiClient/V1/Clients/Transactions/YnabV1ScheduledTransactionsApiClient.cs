using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.Transactions;
using mmazur.YnabApiClient.V1.Models.Transactions;

namespace mmazur.YnabApiClient.V1.Clients.Transactions;

internal sealed class YnabV1ScheduledTransactionsApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, string bearerToken)
    : YnabApiClientBase(httpClientFactory, logger), IYnabV1ScheduledTransactionsApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = new(baseUri, "scheduled_transactions/");
    private readonly Dictionary<Guid, IYnabV1ScheduledTransactionApiClient> _scheduledTransactionClients = [];

    public IYnabV1ScheduledTransactionApiClient this[Guid scheduledTransactionId] =>
        _scheduledTransactionClients.GetOrAdd(scheduledTransactionId, () => new YnabV1ScheduledTransactionApiClient(_httpClientFactory, _logger, _resourcesUri, scheduledTransactionId, bearerToken));

    public Task<ScheduledTransactionsResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<ScheduledTransactionsResponse>(_resourcesUri, bearerToken, cancellationToken);

    public Task<ScheduledTransactionsResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        this.GetAsync<ScheduledTransactionsResponse>(_resourcesUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, bearerToken, cancellationToken);

    public Task<ScheduledTransactionResponse> CreateAsync(SaveScheduledTransaction scheduledTransaction, CancellationToken cancellationToken = default) =>
        this.PostAsync<ScheduledTransactionResponse>(_resourcesUri, new PostScheduledTransactionWrapper { ScheduledTransaction = scheduledTransaction }, bearerToken, cancellationToken);
}