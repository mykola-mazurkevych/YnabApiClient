#pragma warning disable CA1034 // Nested types should not be visible

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using mmazur.YnabApiClient.Extensions;

namespace mmazur.YnabApiClient;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddYnabApiClient()
        {
            services
                .AddHttpClient(
                    YnabApiClient.Name,
                    (serviceProvider, httpClient) =>
                    {
                        var options = serviceProvider.GetRequiredService<IOptions<YnabApiClientOptions>>().Value;
                        httpClient.Configure(options.BaseUri, options.BearerToken);
                    })
                .AddStandardResilienceHandler();

            return services.AddTransient<IYnabApiClient, YnabApiClient>();
        }

        public IServiceCollection AddYnabApiClient(YnabApiClientOptions options)
        {
            services
                .AddHttpClient(YnabApiClient.Name, httpClient => httpClient.Configure(options.BaseUri, options.BearerToken))
                .AddStandardResilienceHandler();

            return services.AddTransient<IYnabApiClient, YnabApiClient>();
        }

        public IServiceCollection AddYnabApiClient(Uri baseUri, string bearerToken)
        {
            services
                .AddHttpClient(YnabApiClient.Name, httpClient => httpClient.Configure(baseUri, bearerToken))
                .AddStandardResilienceHandler();

            return services.AddTransient<IYnabApiClient, YnabApiClient>();
        }

        public IServiceCollection AddYnabApiClient(HttpClient httpClient) =>
            services.AddTransient<IYnabApiClient, YnabApiClient>(serviceProvider => new YnabApiClient(httpClient, serviceProvider.GetService<ILogger<YnabApiClient>>()));
    }
}