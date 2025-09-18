using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.Categories;
using mmazur.YnabApiClient.V1.Models.Categories;

namespace mmazur.YnabApiClient.V1.Clients.Categories;

internal sealed class YnabV1CategoriesApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, string bearerToken)
    : YnabApiClientBase(httpClientFactory, logger), IYnabV1CategoriesApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = new(baseUri, "categories/");
    private readonly Dictionary<Guid, IYnabV1CategoryApiClient> _categoryClients = [];

    public IYnabV1CategoryApiClient this[Guid categoryId] =>
        _categoryClients.GetOrAdd(categoryId, () => new YnabV1CategoryApiClient(_httpClientFactory, _logger, _resourcesUri, categoryId, bearerToken));

    public Task<CategoriesResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<CategoriesResponse>(_resourcesUri, bearerToken, cancellationToken);

    public Task<CategoriesResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        this.GetAsync<CategoriesResponse>(_resourcesUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, bearerToken, cancellationToken);
}