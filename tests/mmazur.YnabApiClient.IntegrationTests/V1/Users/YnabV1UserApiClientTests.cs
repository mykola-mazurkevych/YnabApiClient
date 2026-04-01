using mmazur.YnabApiClient.V1.Users;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.Users;

public sealed class YnabV1UserApiClientTests :
    YnabApiClientTestsBase
{
    private readonly IYnabV1UserApiClient _ynabV1UserApiClient;

    public YnabV1UserApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        _ynabV1UserApiClient = YnabApiClient.V1.User;
    }

    [Fact(DisplayName = "Get User")]
    public async Task GetAsync_ShouldSucceed()
    {
        var userResponse = await _ynabV1UserApiClient.GetAsync();

        Assert.NotNull(userResponse);
        Assert.NotNull(userResponse.User);
    }
}