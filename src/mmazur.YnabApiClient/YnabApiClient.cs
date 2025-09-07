#pragma warning disable CS9113

namespace mmazur.YnabApiClient;

internal sealed class YnabApiClient(IHttpClientFactory httpClientFactory, string bearerToken) : IYnabApiClient;