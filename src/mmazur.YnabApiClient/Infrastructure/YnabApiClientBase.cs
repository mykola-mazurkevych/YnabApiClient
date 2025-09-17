using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using mmazur.YnabApiClient.Exceptions;
using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.Infrastructure.Serialization;
using mmazur.YnabApiClient.V1.Models;

namespace mmazur.YnabApiClient.Infrastructure;

internal abstract class YnabApiClientBase(IHttpClientFactory httpClientFactory)
{
    private const string JsonContentType = "application/json";

    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        Converters =
        {
            new DecimalJsonConverter(),
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
        },
        WriteIndented = true
    };

    protected async Task<TResponse> GetAsync<TResponse>(Uri uri, object? queryParameters, string bearerToken, CancellationToken cancellationToken)
        where TResponse : new()
    {
        using var httpClient = httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));

        var requestUri = uri.AppendQueryParameters(queryParameters);

#if DEBUG
        Console.Write("Request: ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"GET {requestUri}");
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

        DataResponse<TResponse> dataResponse;

        switch (httpResponseMessage.StatusCode)
        {
            case HttpStatusCode.OK:
                dataResponse = await DeserializeResponseContentAsync<DataResponse<TResponse>>(responseContent, cancellationToken).ConfigureAwait(false);
                break;
            case HttpStatusCode.NotFound:
                dataResponse = new DataResponse<TResponse> { Data = new TResponse() };
                break;
            default:
                var errorResponse = await DeserializeResponseContentAsync<ErrorResponse>(responseContent, cancellationToken).ConfigureAwait(false);
                throw new YnabApiClientError(errorResponse.Error.Id, errorResponse.Error.Name, errorResponse.Error.Detail);
        }

        return dataResponse.Data;
    }

    protected async Task<TResponse> PostAsync<TResponse>(Uri uri, object value, string bearerToken, CancellationToken cancellationToken)
    {
        using var httpClient = httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));

        var json = JsonSerializer.Serialize(value, JsonSerializerOptions);

#if DEBUG
        Console.Write("Request: ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"POST {uri}");
        Console.WriteLine(json);
        Console.ResetColor();
#endif

        var stringContent = new StringContent(json, Encoding.UTF8, JsonContentType);
        var httpResponseMessage = await httpClient.PostAsync(uri, stringContent, cancellationToken).ConfigureAwait(false);

#if DEBUG
        var responseContentAsString = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var jsonDocument = JsonDocument.Parse(responseContentAsString);
        Console.WriteLine("Response:");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(JsonSerializer.Serialize(jsonDocument, JsonSerializerOptions));
        Console.ResetColor();
#endif

        await using var responseContent = await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);

        DataResponse<TResponse> dataResponse;

        switch (httpResponseMessage.StatusCode)
        {
            case HttpStatusCode.Created:
                dataResponse = await DeserializeResponseContentAsync<DataResponse<TResponse>>(responseContent, cancellationToken).ConfigureAwait(false);
                break;
            default:
                var errorResponse = await DeserializeResponseContentAsync<ErrorResponse>(responseContent, cancellationToken).ConfigureAwait(false);
                throw new YnabApiClientError(errorResponse.Error.Id, errorResponse.Error.Name, errorResponse.Error.Detail);
        }

        return dataResponse.Data;
    }

    protected async Task<TResponse> PatchAsync<TResponse>(Uri uri, object value, string bearerToken, CancellationToken cancellationToken)
    {
        using var httpClient = httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));

        var json = JsonSerializer.Serialize(value, JsonSerializerOptions);

#if DEBUG
        Console.Write("Request: ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"PATCH {uri}");
        Console.WriteLine(json);
        Console.ResetColor();
#endif

        var stringContent = new StringContent(json, Encoding.UTF8, JsonContentType);
        var httpResponseMessage = await httpClient.PatchAsync(uri, stringContent, cancellationToken).ConfigureAwait(false);

#if DEBUG
        var responseContentAsString = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var jsonDocument = JsonDocument.Parse(responseContentAsString);
        Console.WriteLine("Response:");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(JsonSerializer.Serialize(jsonDocument, JsonSerializerOptions));
        Console.ResetColor();
#endif

        await using var responseContent = await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);

        DataResponse<TResponse> dataResponse;

        switch (httpResponseMessage.StatusCode)
        {
            case HttpStatusCode.Created:
                dataResponse = await DeserializeResponseContentAsync<DataResponse<TResponse>>(responseContent, cancellationToken).ConfigureAwait(false);
                break;
            default:
                var errorResponse = await DeserializeResponseContentAsync<ErrorResponse>(responseContent, cancellationToken).ConfigureAwait(false);
                throw new YnabApiClientError(errorResponse.Error.Id, errorResponse.Error.Name, errorResponse.Error.Detail);
        }

        return dataResponse.Data;
    }

    protected async Task<TResponse> PutAsync<TResponse>(Uri uri, object value, string bearerToken, CancellationToken cancellationToken)
    {
        using var httpClient = httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));

        var json = JsonSerializer.Serialize(value, JsonSerializerOptions);

#if DEBUG
        Console.Write("Request: ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"PUT {uri}");
        Console.WriteLine(json);
        Console.ResetColor();
#endif

        var stringContent = new StringContent(json, Encoding.UTF8, JsonContentType);
        var httpResponseMessage = await httpClient.PutAsync(uri, stringContent, cancellationToken).ConfigureAwait(false);

#if DEBUG
        var responseContentAsString = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var jsonDocument = JsonDocument.Parse(responseContentAsString);
        Console.WriteLine("Response:");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(JsonSerializer.Serialize(jsonDocument, JsonSerializerOptions));
        Console.ResetColor();
#endif

        await using var responseContent = await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);

        DataResponse<TResponse> dataResponse;

        switch (httpResponseMessage.StatusCode)
        {
            case HttpStatusCode.OK:
                dataResponse = await DeserializeResponseContentAsync<DataResponse<TResponse>>(responseContent, cancellationToken).ConfigureAwait(false);
                break;
            default:
                var errorResponse = await DeserializeResponseContentAsync<ErrorResponse>(responseContent, cancellationToken).ConfigureAwait(false);
                throw new YnabApiClientError(errorResponse.Error.Id, errorResponse.Error.Name, errorResponse.Error.Detail);
        }

        return dataResponse.Data;
    }

    protected async Task<TResponse> DeleteAsync<TResponse>(Uri uri, string bearerToken, CancellationToken cancellationToken)
    {
        using var httpClient = httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));

#if DEBUG
        Console.Write("Request: ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"DELETE {uri}");
        Console.ResetColor();
#endif

        var httpResponseMessage = await httpClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);

#if DEBUG
        var responseContentAsString = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var jsonDocument = JsonDocument.Parse(responseContentAsString);
        Console.WriteLine("Response:");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(JsonSerializer.Serialize(jsonDocument, JsonSerializerOptions));
        Console.ResetColor();
#endif

        await using var responseContent = await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);

        DataResponse<TResponse> dataResponse;

        switch (httpResponseMessage.StatusCode)
        {
            case HttpStatusCode.OK:
                dataResponse = await DeserializeResponseContentAsync<DataResponse<TResponse>>(responseContent, cancellationToken).ConfigureAwait(false);
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