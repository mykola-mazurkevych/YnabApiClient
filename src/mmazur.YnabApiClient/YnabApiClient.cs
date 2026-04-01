using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1;

namespace mmazur.YnabApiClient;

internal sealed class YnabApiClient :
    IYnabApiClient
{
    internal static string Name => nameof(YnabApiClient);

    private readonly HttpClient _httpClient;
    private readonly ILogger? _logger;

    public YnabApiClient(IHttpClientFactory httpClientFactory, ILogger<YnabApiClient>? logger)
    {
        _httpClient = httpClientFactory.CreateClient(Name);
        _logger = logger;
    }

    public YnabApiClient(HttpClient httpClient, ILogger? logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public IYnabV1ApiClient V1 => new YnabV1ApiClient(_httpClient, _logger);
}