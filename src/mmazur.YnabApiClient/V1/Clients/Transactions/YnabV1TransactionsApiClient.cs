using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.Transactions;
using mmazur.YnabApiClient.V1.Models.Transactions;

namespace mmazur.YnabApiClient.V1.Clients.Transactions;

internal sealed class YnabV1TransactionsApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, string bearerToken)
    : YnabApiClientBase(httpClientFactory, logger), IYnabV1TransactionsApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = new(baseUri, "transactions/");

    public IYnabV1TransactionApiClient this[string transactionsId] =>
        new YnabV1TransactionApiClient(_httpClientFactory, _logger, _resourcesUri, transactionsId, bearerToken);

    public Task<TransactionsResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<TransactionsResponse>(_resourcesUri, bearerToken, cancellationToken);

    public Task<TransactionsResponse?> GetAsync(DateOnly sinceDate, CancellationToken cancellationToken = default) =>
        this.GetAsync<TransactionsResponse>(_resourcesUri, new { since_date = sinceDate }, bearerToken, cancellationToken);

    public Task<TransactionsResponse?> GetAsync(DateOnly sinceDate, TransactionType type, CancellationToken cancellationToken = default) =>
        this.GetAsync<TransactionsResponse>(_resourcesUri, new { since_date = sinceDate, type = type.ToCustomString() }, bearerToken, cancellationToken);

    public Task<TransactionsResponse?> GetAsync(DateOnly sinceDate, long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        this.GetAsync<TransactionsResponse>(_resourcesUri, new { since_date = sinceDate, last_knowledge_of_server = lastKnowledgeOfServer }, bearerToken, cancellationToken);

    public Task<TransactionsResponse?> GetAsync(DateOnly sinceDate, TransactionType type, long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        this.GetAsync<TransactionsResponse>(_resourcesUri, new { since_date = sinceDate, type = type.ToCustomString(), last_knowledge_of_server = lastKnowledgeOfServer }, bearerToken, cancellationToken);

    public Task<TransactionsResponse?> GetAsync(TransactionType type, CancellationToken cancellationToken = default) =>
        this.GetAsync<TransactionsResponse>(_resourcesUri, new { type = type.ToCustomString() }, bearerToken, cancellationToken);

    public Task<TransactionsResponse?> GetAsync(TransactionType type, long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        this.GetAsync<TransactionsResponse>(_resourcesUri, new { type = type.ToCustomString(), last_knowledge_of_server = lastKnowledgeOfServer }, bearerToken, cancellationToken);

    public Task<TransactionsResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        this.GetAsync<TransactionsResponse>(_resourcesUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, bearerToken, cancellationToken);

    public Task<SaveTransactionResponse> CreateAsync(NewTransaction transaction, CancellationToken cancellationToken = default) =>
        this.PostAsync<SaveTransactionResponse>(_resourcesUri, new PostTransactionsWrapper { Transaction = transaction }, bearerToken, cancellationToken);

    public Task<SaveTransactionsResponse> CreateAsync(IEnumerable<NewTransaction> transactions, CancellationToken cancellationToken = default) =>
        this.PostAsync<SaveTransactionsResponse>(_resourcesUri, new PostTransactionsWrapper { Transactions = transactions }, bearerToken, cancellationToken);

    public Task<SaveTransactionResponse> UpdateAsync(SaveTransactionWithIdOrImportId transaction, CancellationToken cancellationToken = default) =>
        this.PatchAsync<SaveTransactionResponse>(_resourcesUri, new PatchTransactionsWrapper { Transactions = [transaction] }, bearerToken, cancellationToken);

    public Task<SaveTransactionsResponse> UpdateAsync(IEnumerable<SaveTransactionWithIdOrImportId> transactions, CancellationToken cancellationToken = default) =>
        this.PatchAsync<SaveTransactionsResponse>(_resourcesUri, new PatchTransactionsWrapper { Transactions = transactions }, bearerToken, cancellationToken);

    public Task<TransactionsImportResponse> ImportAsync(IEnumerable<object> transactions, CancellationToken cancellationToken = default) =>
        throw new NotImplementedException();
}