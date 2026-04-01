using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

internal sealed class YnabV1TransactionsApiClient(HttpClient httpClient, Uri parentUri, ILogger? logger) :
    YnabApiClientBase(httpClient, logger),
    IYnabV1TransactionsApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = parentUri.AppendPath("transactions/");

    public IYnabV1TransactionApiClient this[string transactionsId] =>
        new YnabV1TransactionApiClient(_httpClient, _resourcesUri, transactionsId, _logger);

    public Task<TransactionsResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<TransactionsResponse>(_resourcesUri, cancellationToken);

    public Task<TransactionsResponse?> GetAsync(DateOnly sinceDate, CancellationToken cancellationToken = default) =>
        GetAsync<TransactionsResponse>(_resourcesUri, new { since_date = sinceDate }, cancellationToken);

    public Task<TransactionsResponse?> GetAsync(DateOnly sinceDate, TransactionType type, CancellationToken cancellationToken = default) =>
        GetAsync<TransactionsResponse>(_resourcesUri, new { since_date = sinceDate, type = type.ToCustomString() }, cancellationToken);

    public Task<TransactionsResponse?> GetAsync(DateOnly sinceDate, long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        GetAsync<TransactionsResponse>(_resourcesUri, new { since_date = sinceDate, last_knowledge_of_server = lastKnowledgeOfServer }, cancellationToken);

    public Task<TransactionsResponse?> GetAsync(DateOnly sinceDate, TransactionType type, long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        GetAsync<TransactionsResponse>(_resourcesUri, new { since_date = sinceDate, type = type.ToCustomString(), last_knowledge_of_server = lastKnowledgeOfServer }, cancellationToken);

    public Task<TransactionsResponse?> GetAsync(TransactionType type, CancellationToken cancellationToken = default) =>
        GetAsync<TransactionsResponse>(_resourcesUri, new { type = type.ToCustomString() }, cancellationToken);

    public Task<TransactionsResponse?> GetAsync(TransactionType type, long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        GetAsync<TransactionsResponse>(_resourcesUri, new { type = type.ToCustomString(), last_knowledge_of_server = lastKnowledgeOfServer }, cancellationToken);

    public Task<TransactionsResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        GetAsync<TransactionsResponse>(_resourcesUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, cancellationToken);

    public Task<SaveTransactionResponse> CreateAsync(NewTransaction transaction, CancellationToken cancellationToken = default) =>
        PostAsync<SaveTransactionResponse>(_resourcesUri, new PostTransactionsWrapper { Transaction = transaction }, cancellationToken);

    public Task<SaveTransactionsResponse> CreateAsync(IEnumerable<NewTransaction> transactions, CancellationToken cancellationToken = default) =>
        PostAsync<SaveTransactionsResponse>(_resourcesUri, new PostTransactionsWrapper { Transactions = transactions }, cancellationToken);

    public Task<SaveTransactionResponse> UpdateAsync(SaveTransactionWithIdOrImportId transaction, CancellationToken cancellationToken = default) =>
        PatchAsync<SaveTransactionResponse>(_resourcesUri, new PatchTransactionsWrapper { Transactions = [transaction] }, cancellationToken);

    public Task<SaveTransactionsResponse> UpdateAsync(IEnumerable<SaveTransactionWithIdOrImportId> transactions, CancellationToken cancellationToken = default) =>
        PatchAsync<SaveTransactionsResponse>(_resourcesUri, new PatchTransactionsWrapper { Transactions = transactions }, cancellationToken);

    public Task<TransactionsImportResponse> ImportAsync(CancellationToken cancellationToken = default) =>
        PostAsync<TransactionsImportResponse>(_resourcesUri.AppendPath("import"), new { }, cancellationToken);
}