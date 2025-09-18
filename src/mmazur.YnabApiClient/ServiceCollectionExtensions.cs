using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace mmazur.YnabApiClient;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddYnabApiClient(this IServiceCollection services, string bearerToken) =>
        services
            .AddHttpClient()
            .AddTransient<IYnabApiClient, YnabApiClient>(serviceProvider =>
                new YnabApiClient(
                    serviceProvider.GetRequiredService<IHttpClientFactory>(),
                    serviceProvider.GetService<ILogger<YnabApiClient>>(),
                    bearerToken));

    public static IServiceCollection AddYnabApiClient(this IServiceCollection services, ILogger logger, string bearerToken) =>
        services
            .AddHttpClient()
            .AddTransient<IYnabApiClient, YnabApiClient>(serviceProvider =>
                new YnabApiClient(
                    serviceProvider.GetRequiredService<IHttpClientFactory>(),
                    logger,
                    bearerToken));
}