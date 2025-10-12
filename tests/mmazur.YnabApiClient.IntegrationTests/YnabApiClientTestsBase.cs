#pragma warning disable CA1515 // Consider making public types internal

using Meziantou.Extensions.Logging.Xunit;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Soenneker.Utils.AutoBogus;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests;

public abstract class YnabApiClientTestsBase : IClassFixture<YnabApiClientTestsFixture>
{
    protected YnabApiClientTestsBase(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper)
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging(builder => builder
                .AddProvider(new XUnitLoggerProvider(outputHelper))
                .SetMinimumLevel(LogLevel.Debug))
            .AddYnabApiClient(new YnabApiClientOptions { BaseUri = fixture.BaseUri, BearerToken = "test" })
            .BuildServiceProvider();

        this.YnabApiClient = serviceProvider.GetRequiredService<IYnabApiClient>();
    }

    protected AutoFaker Faker { get; } = new();

    protected IYnabApiClient YnabApiClient { get; }
}