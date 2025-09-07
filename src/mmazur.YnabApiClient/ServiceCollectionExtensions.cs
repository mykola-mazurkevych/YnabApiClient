using Microsoft.Extensions.DependencyInjection;

namespace mmazur.YnabApiClient;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddYnabApiClient(this IServiceCollection services, string bearerToken) =>
        services
            .AddHttpClient()
            .AddTransient<IYnabApiClient, YnabApiClient>(serviceProvider => new YnabApiClient(serviceProvider.GetRequiredService<IHttpClientFactory>(), bearerToken));
}