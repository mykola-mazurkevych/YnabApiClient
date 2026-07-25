# Publish Readiness Review Notes

Date: 2026-04-02
Scope: Consolidated notes from architecture/code review for NuGet publication readiness.

## Current Status Snapshot

### Already addressed

1. Query parameter DateOnly serialization now uses ISO format.
2. Decimal milliunit conversion uses rounding instead of truncation.
3. Query parameter reflection metadata caching added.
4. Request JSON is compact (no pretty-printing for wire payloads).
5. Transaction create payload ambiguity fixed by splitting wrappers:
	 - `PostTransactionWrapper` for single create
	 - `PostTransactionsWrapper` for bulk create
6. DTO collection model refactor applied to use `IReadOnlyList` init properties while keeping `record` types.

### Reverted / still open

1. Exception contract improvements reverted.
2. Options validation improvements reverted.
3. Package metadata and version unification changes not applied.

## Remaining Items To Fix

Ordered by severity/impact.

### 1) Exception contract for consumers (High)

Files:
- `src/mmazur.YnabApiClient/V1/Exceptions/YnabApiClientException.cs`
- `src/mmazur.YnabApiClient/V1/Common/YnabApiClientBase.cs`

Current issue:
- `YnabApiClientException` suppresses CA1032 and has no standard constructors.
- Exception does not expose HTTP status code.
- Caller cannot reliably branch by 401/429/422 without parsing text.

Recommended fix:
- Add standard constructors (`()`, `(string)`, `(string, Exception)`).
- Add `HttpStatusCode? StatusCode` property.
- Keep YNAB error fields (`Id`, `Name`, `Detail`) and include them in message.
- Throw with status from `YnabApiClientBase` default branch.

### 5) Options validation and fail-fast config checks (High)

Files:
- `src/mmazur.YnabApiClient/YnabApiClientOptions.cs`
- `src/mmazur.YnabApiClient/ServiceCollectionExtensions.cs`

Current issue:
- `BearerToken` can be empty/whitespace.
- `BaseUri` can be invalid/non-absolute in runtime paths.

Recommended fix:
- Add data annotations on `BearerToken` (`Required`, `MinLength(1)`).
- In `AddYnabApiClient()`, add options validation with:
	- absolute URI check
	- non-empty token check
	- `ValidateOnStart()`
- In overloads that accept `YnabApiClientOptions` and `(Uri, string)`, validate arguments and throw `ArgumentException` early.

### 8) Version source inconsistency (Medium)

Files:
- `src/mmazur.YnabApiClient/mmazur.YnabApiClient.csproj`
- `Directory.Build.props`

Current issue:
- Package version is `1.0.0-alpha` in project file.
- Global version in build props is `1.0.0`.

Recommended fix:
- Use one authoritative version source.
- Suggested approach:
	- Keep version only in `Directory.Build.props` for consistency.
	- Remove `<Version>` from package csproj.
	- If prerelease package is desired, encode prerelease once in shared version source.

### 9) NuGet metadata and SourceLink completeness (Medium)

File:
- `src/mmazur.YnabApiClient/mmazur.YnabApiClient.csproj`

Current issue:
- Metadata is minimal.
- SourceLink and symbol package settings are missing.

Recommended fix:
- Add package metadata:
	- `PackageTags`
	- `PackageProjectUrl`
	- `PackageReadmeFile`
- Include root `README.md` in package.
- Add SourceLink package (`Microsoft.SourceLink.GitHub`, `PrivateAssets=All`).
- Add deterministic/symbol settings:
	- `PublishRepositoryUrl=true`
	- `EmbedUntrackedSources=true`
	- `Deterministic=true`
	- `IncludeSymbols=true`
	- `SymbolPackageFormat=snupkg`

## Other Important Items Still Recommended

1. `AddYnabApiClient(HttpClient)` overload is risky and bypasses factory lifetimes/resilience conventions.
2. Many API client properties allocate new child clients on each access.
3. Duplicate `_httpClient`/`_logger` storage across child clients adds unnecessary memory overhead.
4. Integration tests mostly assert non-null and do not cover critical negative/error paths.

## Suggested Execution Order

1. Implement item 1 (exception contract).
2. Implement item 5 (options validation).
3. Implement item 8 (single version source).
4. Implement item 9 (metadata + SourceLink).
5. Run build + test pass and update README release notes.

