using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Clients.Categories;
using mmazur.YnabApiClient.V1.Interfaces.Categories;
using mmazur.YnabApiClient.V1.Interfaces.Months;
using mmazur.YnabApiClient.V1.Models.Months;

namespace mmazur.YnabApiClient.V1.Clients.Months;

internal sealed class YnabV1MonthApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, DateOnly month, string bearerToken)
    : YnabApiClientBase(httpClientFactory), IYnabV1MonthApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly Uri _resourceUri = new(baseUri, $"{month}/");

    public IYnabV1CategoriesApiClient Categories => new YnabV1CategoriesApiClient(_httpClientFactory, _resourceUri, bearerToken);

    public Task<MonthWithCategoriesResponse> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<MonthWithCategoriesResponse>(_resourceUri, null, bearerToken, cancellationToken);
}