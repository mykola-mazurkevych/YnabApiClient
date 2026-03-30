# YnabApiClient

Typed .NET client for the [YNAB API](https://api.ynab.com/).

The library provides a strongly-typed, hierarchical API surface for YNAB v1 endpoints, with support for:

- Dependency Injection (`IServiceCollection`)
- `IHttpClientFactory`
- Structured logging via `Microsoft.Extensions.Logging`
- Async-first API calls with `CancellationToken`

## Package

- Package ID: `mmazur.YnabApiClient`
- Current package version in repository: `1.0.0-alpha`
- Repository: <https://github.com/mykola-mazurkevych/YnabApiClient>

Install with:

```bash
dotnet add package mmazur.YnabApiClient
```

## Requirements

- .NET SDK compatible with the project target framework (`net10.0` in this repository)
- YNAB Personal Access Token

Generate a token in YNAB account settings and keep it secure.

## Quick Start

### 1. Register the client in DI

```csharp
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mmazur.YnabApiClient;

var configuration = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json", optional: true)
	.AddEnvironmentVariables()
	.Build();

var services = new ServiceCollection()
	.Configure<YnabApiClientOptions>(opts => configuration.GetSection("Ynab").Bind(opts))
	.AddYnabApiClient();

var serviceProvider = services.BuildServiceProvider();
var ynab = serviceProvider.GetRequiredService<IYnabApiClient>();
```

`appsettings.json` example:

```json
{
  "Ynab": {
	"BaseUri": "https://api.ynab.com/",
	"BearerToken": "your-ynab-personal-access-token"
  }
}
```

### 2. Call the API

```csharp
using mmazur.YnabApiClient;

public static async Task PrintBudgetsAsync(IYnabApiClient ynab, CancellationToken cancellationToken = default)
{
	var budgets = await ynab.V1.Budgets.GetAsync(cancellationToken);

	if (budgets is null)
	{
		Console.WriteLine("No budgets returned.");
		return;
	}

	foreach (var budget in budgets.Budgets)
	{
		Console.WriteLine($"{budget.Id} | {budget.Name}");
	}
}
```

## Configuration Options

`YnabApiClientOptions`:

- `BaseUri` (`Uri`): defaults to `https://api.ynab.com/`
- `BearerToken` (`string`, required): YNAB personal access token

You can register with either:

- `AddYnabApiClient()` (uses `IOptions<YnabApiClientOptions>`)
- `AddYnabApiClient(YnabApiClientOptions options)`
- `AddYnabApiClient(ILogger logger, YnabApiClientOptions options)`

## API Shape

Root client:

- `IYnabApiClient`
  - `V1`
	- `Budgets`
	- `User`

Budget-scoped sub-clients are available through `ynab.V1.Budgets[budgetId]`:

- `Settings`
- `Accounts`
- `Categories`
- `Months`
- `PayeeLocations`
- `Payees`
- `ScheduledTransactions`
- `Transactions`

Example navigation:

```csharp
var budgetId = Guid.Parse("00000000-0000-0000-0000-000000000000");

var accounts = await ynab
	.V1
	.Budgets[budgetId]
	.Accounts
	.GetAsync(cancellationToken);
```

## Transaction Example

```csharp
using mmazur.YnabApiClient.V1.Transactions.Models;

public static async Task CreateTransactionAsync(
	IYnabApiClient ynab,
	Guid budgetId,
	Guid accountId,
	Guid categoryId,
	Guid? payeeId,
	CancellationToken cancellationToken = default)
{
	var newTransaction = new NewTransaction
	{
		AccountId = accountId,
		Date = DateOnly.FromDateTime(DateTime.UtcNow),
		Amount = -5000,
		PayeeId = payeeId,
		CategoryId = categoryId,
		ClearedStatus = TransactionClearedStatus.Cleared
	};

	var response = await ynab
		.V1
		.Budgets[budgetId]
		.Transactions
		.CreateAsync(newTransaction, cancellationToken);

	Console.WriteLine($"Created transaction id: {response.Transaction?.Id}");
}
```

## Error Handling

For non-success responses, the client throws `YnabApiClientException` with:

- `Id`
- `Name`
- `Detail`

Use standard `try/catch` around API calls:

```csharp
using mmazur.YnabApiClient.V1.Exceptions;

try
{
	var user = await ynab.V1.User.GetAsync(cancellationToken);
}
catch (YnabApiClientException ex)
{
	Console.WriteLine($"YNAB API error: {ex.Name} ({ex.Id}) - {ex.Detail}");
}
```

## Logging

Enable `Debug` level logging to inspect outgoing request metadata and serialized content.

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection()
	.AddLogging(builder => builder
		.AddConsole()
		.SetMinimumLevel(LogLevel.Debug))
	.AddYnabApiClient(new YnabApiClientOptions
	{
		BaseUri = new Uri("https://api.ynab.com/"),
		BearerToken = "your-token"
	});
```

## Sample App

A runnable sample is available in:

- `samples/mmazur.YnabApiClient.Sample`

The sample demonstrates:

- Loading token from User Secrets
- DI registration
- Listing budgets
- Creating an account
- Creating a transaction

Run it:

```bash
dotnet run --project samples/mmazur.YnabApiClient.Sample
```

## Integration Tests

Integration tests are in:

- `tests/mmazur.YnabApiClient.IntegrationTests`

They use Prism (OpenAPI mock server) through Testcontainers.

Run tests:

```bash
dotnet test
```

## License

MIT (see `LICENSE`).