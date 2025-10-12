using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1.Categories.Models;
using mmazur.YnabApiClient.V1.Common;

namespace mmazur.YnabApiClient.V1.Categories;

internal sealed class YnabV1CategoriesApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, string bearerToken) :
    YnabApiClientBase(httpClientFactory, logger),
    IYnabV1CategoriesApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = new(baseUri, "categories/");

    public IYnabV1CategoryApiClient this[Guid categoryId] =>
        new YnabV1CategoryApiClient(_httpClientFactory, _logger, _resourcesUri, categoryId, bearerToken);

    public Task<CategoriesResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<CategoriesResponse>(_resourcesUri, bearerToken, cancellationToken);

    public Task<CategoriesResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        this.GetAsync<CategoriesResponse>(_resourcesUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, bearerToken, cancellationToken);
}