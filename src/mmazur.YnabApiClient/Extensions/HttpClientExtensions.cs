using System.Net.Http.Headers;
using System.Net.Mime;

namespace mmazur.YnabApiClient.Extensions;

internal static class HttpClientExtensions
{
    extension(HttpClient httpClient)
    {
        public void Configure(Uri baseUri, string bearerToken)
        {
            httpClient.BaseAddress = baseUri;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
        }
    }
}