#pragma warning disable IDE0055 // Fix formatting

using System.ComponentModel;
using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using mmazur.YnabApiClient;
using mmazur.YnabApiClient.Sample;

Console.WriteLine(
    """
    #######################################
    #    mmazur YNAB API Client Sample    #
    #######################################
    """);

var configuration = new ConfigurationBuilder()
    .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
    .Build();

var serviceProvider = new ServiceCollection()
    .AddSingleton<IApplication, Application>()
    .AddYnabApiClient(configuration.GetSection("Ynab:BearerToken").Value ?? throw new InvalidAsynchronousStateException())
    .BuildServiceProvider();

await serviceProvider.GetRequiredService<IApplication>().RunAsync().ConfigureAwait(false);