using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace mmazur.YnabApiClient;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddYnabApiClient(this IServiceCollection services) =>
        services
            .AddHttpClient()
            .AddTransient<IYnabApiClient, YnabApiClient>(serviceProvider =>
                new YnabApiClient(
                    serviceProvider.GetRequiredService<IHttpClientFactory>(),
                    serviceProvider.GetService<ILogger<YnabApiClient>>(),
                    serviceProvider.GetRequiredService<IOptions<YnabApiClientOptions>>().Value));

    public static IServiceCollection AddYnabApiClient(this IServiceCollection services, YnabApiClientOptions options) =>
        services
            .AddHttpClient()
            .AddTransient<IYnabApiClient, YnabApiClient>(serviceProvider =>
                new YnabApiClient(
                    serviceProvider.GetRequiredService<IHttpClientFactory>(),
                    serviceProvider.GetService<ILogger<YnabApiClient>>(),
                    options));

    public static IServiceCollection AddYnabApiClient(this IServiceCollection services, ILogger logger, YnabApiClientOptions options) =>
        services
            .AddHttpClient()
            .AddTransient<IYnabApiClient, YnabApiClient>(serviceProvider =>
                new YnabApiClient(
                    serviceProvider.GetRequiredService<IHttpClientFactory>(),
                    logger,
                    options));
}