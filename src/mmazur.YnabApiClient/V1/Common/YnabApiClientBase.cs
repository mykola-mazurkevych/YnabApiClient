#pragma warning disable IDE0010 // Add missing cases

using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Common.Models;
using mmazur.YnabApiClient.V1.Common.Serialization;
using mmazur.YnabApiClient.V1.Exceptions;

namespace mmazur.YnabApiClient.V1.Common;

internal abstract class YnabApiClientBase(HttpClient httpClient, ILogger? logger)
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        Converters =
        {
            new DecimalJsonConverter(),
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
        },
        WriteIndented = true
    };

    protected Task<TData?> GetAsync<TData>(Uri uri, CancellationToken cancellationToken)
        where TData : class =>
        SendAsync<TData>(HttpMethod.Get, uri, queryParameters: null, content: null, cancellationToken);

    protected Task<TData?> GetAsync<TData>(Uri uri, object? queryParameters, CancellationToken cancellationToken)
        where TData : class =>
        SendAsync<TData>(HttpMethod.Get, uri, queryParameters, content: null, cancellationToken);

    protected async Task<TData> PostAsync<TData>(Uri uri, object content, CancellationToken cancellationToken)
        where TData : class
    {
        var data = await SendAsync<TData>(HttpMethod.Post, uri, queryParameters: null, content: content, cancellationToken).ConfigureAwait(false);

        return data ?? throw new InvalidOperationException($"The {HttpMethod.Post} should not return null data.");
    }

    protected async Task<TData> PatchAsync<TData>(Uri uri, object content, CancellationToken cancellationToken)
        where TData : class
    {
        var data = await SendAsync<TData>(HttpMethod.Patch, uri, queryParameters: null, content: content, cancellationToken).ConfigureAwait(false);

        return data ?? throw new InvalidOperationException($"The {HttpMethod.Patch} should not return null data.");
    }

    protected async Task<TData> PutAsync<TData>(Uri uri, object content, CancellationToken cancellationToken)
        where TData : class
    {
        var data = await SendAsync<TData>(HttpMethod.Put, uri, queryParameters: null, content: content, cancellationToken).ConfigureAwait(false);

        return data ?? throw new InvalidOperationException($"The {HttpMethod.Put} should not return null data.");
    }

    protected async Task<TData> DeleteAsync<TData>(Uri uri, CancellationToken cancellationToken)
        where TData : class
    {
        var data = await SendAsync<TData>(HttpMethod.Delete, uri, queryParameters: null, content: null, cancellationToken).ConfigureAwait(false);

        return data ?? throw new InvalidOperationException($"The {HttpMethod.Delete} should not return null data.");
    }

    private async Task<TData?> SendAsync<TData>(HttpMethod httpMethod, Uri uri, object? queryParameters, object? content, CancellationToken cancellationToken)
        where TData : class
    {
        var requestUri = uri.AppendQueryParameters(queryParameters);

        using var httpRequestMessage = new HttpRequestMessage(httpMethod, requestUri);

        if (logger is not null)
        {
            YnabApiClientBaseLogMessages.SendingRequest(logger, httpMethod, requestUri);
        }

        if (content is not null)
        {
            var jsonContent = JsonSerializer.Serialize(content, JsonSerializerOptions);

            if (logger is not null)
            {
                YnabApiClientBaseLogMessages.Content(logger, jsonContent);
            }

            httpRequestMessage.Content = new StringContent(jsonContent, Encoding.UTF8, MediaTypeNames.Application.Json);
        }

        using var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, cancellationToken).ConfigureAwait(false);

        if (logger is not null)
        {
            YnabApiClientBaseLogMessages.ReceivedStatusCode(logger, httpResponseMessage.StatusCode);
        }

        await using var responseContent = await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);

        var jsonNode = await JsonNode.ParseAsync(responseContent, cancellationToken: cancellationToken).ConfigureAwait(false);

        if (logger?.IsEnabled(LogLevel.Debug) == true)
        {
            var responseContentJson = jsonNode?.ToJsonString(JsonSerializerOptions);

            YnabApiClientBaseLogMessages.Content(logger, responseContentJson);
        }

        switch (httpResponseMessage.StatusCode)
        {
            case HttpStatusCode.OK:
            case HttpStatusCode.Created:
            case (HttpStatusCode)209:
                var dataResponse = jsonNode.Deserialize<DataResponse<TData>>(JsonSerializerOptions) ??
                                   throw new InvalidOperationException("Deserialized response is null.");

                return dataResponse.Data;
            case HttpStatusCode.NotFound:
                return null;
            default:
                var errorResponse = jsonNode.Deserialize<ErrorResponse>(JsonSerializerOptions) ??
                                    throw new InvalidOperationException("Deserialized response is null.");

                throw new YnabApiClientException(errorResponse.Error.Id, errorResponse.Error.Name, errorResponse.Error.Detail);
        }
    }
}

internal static partial class YnabApiClientBaseLogMessages
{
    [LoggerMessage(Level = LogLevel.Debug, Message = "Sending {Method} to {Uri}")]
    public static partial void SendingRequest(ILogger logger, HttpMethod method, Uri uri);

    [LoggerMessage(Level = LogLevel.Debug, Message = "{Content}")]
    public static partial void Content(ILogger logger, string? content);

    [LoggerMessage(Level = LogLevel.Debug, Message = "Received {StatusCode}")]
    public static partial void ReceivedStatusCode(ILogger logger, HttpStatusCode statusCode);
}