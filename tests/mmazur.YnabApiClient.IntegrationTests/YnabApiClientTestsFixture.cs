#pragma warning disable CA1515 // Consider making public types internal

using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;

using Xunit;

namespace mmazur.YnabApiClient.IntegrationTests;

public sealed class YnabApiClientTestsFixture : IAsyncLifetime
{
    private const string OpenApiSpecFileName = "open_api_spec.yaml";
    private const int Port = 4010;

    private Uri? _baseUri;
    private IContainer? _prismContainer;

    public Uri BaseUri => _baseUri ?? throw new InvalidOperationException("Base uri is not initialized.");

    public async Task InitializeAsync()
    {
        var openApiSpecFileInfo = new FileInfo(Path.GetFullPath(OpenApiSpecFileName));

        if (!openApiSpecFileInfo.Exists)
        {
            throw new FileNotFoundException($"OpenAPI specification file {openApiSpecFileInfo.Name} not found");
        }

        _prismContainer = new ContainerBuilder("stoplight/prism:latest")
            .WithBindMount(openApiSpecFileInfo.FullName, $"/tmp/{openApiSpecFileInfo.Name}", AccessMode.ReadOnly)
            .WithCommand("mock", "-h", "0.0.0.0", $"/tmp/{openApiSpecFileInfo.Name}")
            .WithPortBinding(Port, assignRandomHostPort: true)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilInternalTcpPortIsAvailable(Port))
            .Build();

        await _prismContainer.StartAsync().ConfigureAwait(false);

        var hostPort = _prismContainer.GetMappedPublicPort(Port);
        _baseUri = new Uri($"http://localhost:{hostPort}/");
    }

    public async Task DisposeAsync()
    {
        if (_prismContainer is not null)
        {
            await _prismContainer.StopAsync().ConfigureAwait(false);
            await _prismContainer.DisposeAsync().ConfigureAwait(false);
        }
    }
}