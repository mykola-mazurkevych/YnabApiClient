using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

using mmazur.YnabApiClient.Exceptions;
using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Models;

namespace mmazur.YnabApiClient.Infrastructure;

internal abstract class YnabApiClientBase(IHttpClientFactory httpClientFactory)
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new() { Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }, WriteIndented = true };

    protected async Task<TData> GetDataAsync<TData>(Uri resourceUri, object? queryParameters, string bearerToken, CancellationToken cancellationToken)
        where TData : new()
    {
        using var httpClient = httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var requestUri = resourceUri.AppendQueryParameters(queryParameters);

#if DEBUG
        Console.Write("Request: ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(requestUri);
        Console.ResetColor();
#endif

        var httpResponseMessage = await httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

#if DEBUG
        var responseContentAsString = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var jsonDocument = JsonDocument.Parse(responseContentAsString);
        Console.WriteLine("Response:");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(JsonSerializer.Serialize(jsonDocument, JsonSerializerOptions));
        Console.ResetColor();
#endif

        await using var responseContent = await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);

        DataResponse<TData> dataResponse;

        switch (httpResponseMessage.StatusCode)
        {
            case HttpStatusCode.OK:
                dataResponse = await DeserializeResponseContentAsync<DataResponse<TData>>(responseContent, cancellationToken).ConfigureAwait(false);
                break;
            case HttpStatusCode.NotFound:
                dataResponse = new DataResponse<TData> { Data = new TData() };
                break;
            default:
                var errorResponse = await DeserializeResponseContentAsync<ErrorResponse>(responseContent, cancellationToken).ConfigureAwait(false);
                throw new YnabApiClientError(errorResponse.Error.Id, errorResponse.Error.Name, errorResponse.Error.Detail);
        }

        return dataResponse.Data;
    }

    private static async Task<TResponse> DeserializeResponseContentAsync<TResponse>(Stream responseContent, CancellationToken cancellationToken)
    {
        var response = await JsonSerializer.DeserializeAsync<TResponse>(responseContent, JsonSerializerOptions, cancellationToken).ConfigureAwait(false) ??
                       throw new InvalidOperationException("Deserialized response is null.");

        return response;
    }
}