using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Categories.Models;
using mmazur.YnabApiClient.V1.Common;

namespace mmazur.YnabApiClient.V1.Categories;

internal sealed class YnabV1CategoriesApiClient(HttpClient httpClient, Uri parentUri, ILogger? logger) :
    YnabApiClientBase(httpClient, logger),
    IYnabV1CategoriesApiClient,
    IYnabV1MonthCategoriesApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = parentUri.AppendPath("categories/");

    public IYnabV1CategoryApiClient this[Guid categoryId] =>
        new YnabV1CategoryApiClient(_httpClient, _resourcesUri, categoryId, _logger);

    IYnabV1MonthCategoryApiClient IYnabV1MonthCategoriesApiClient.this[Guid categoryId] =>
        new YnabV1CategoryApiClient(_httpClient, _resourcesUri, categoryId, _logger);

    public Task<CategoriesResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<CategoriesResponse>(_resourcesUri, cancellationToken);

    public Task<CategoriesResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        GetAsync<CategoriesResponse>(_resourcesUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, cancellationToken);
}