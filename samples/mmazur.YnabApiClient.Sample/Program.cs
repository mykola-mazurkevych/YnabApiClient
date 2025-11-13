#pragma warning disable CA1303  // Do not pass literals as localized parameters
#pragma warning disable IDE0055 // Fix formatting

using System.Globalization;
using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient;
using mmazur.YnabApiClient.Sample;

Console.WriteLine(Resources.ResourceManager.GetString("Header", CultureInfo.InvariantCulture));

var configuration = new ConfigurationBuilder()
    .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
    .Build();

var serviceProvider = new ServiceCollection()
    .AddSingleton<IApplication, Application>()
    .AddLogging(loggingBuilder => loggingBuilder.AddConsole())
    .Configure<YnabApiClientOptions>(ynabApiClientOptions => configuration.GetSection("Ynab").Bind(ynabApiClientOptions))
    .AddYnabApiClient()
    .BuildServiceProvider();

var app = serviceProvider.GetRequiredService<IApplication>();

await app.RunAsync().ConfigureAwait(false);

Environment.Exit(0);