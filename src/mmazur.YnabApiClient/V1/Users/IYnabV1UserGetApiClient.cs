using mmazur.YnabApiClient.V1.Users.Models;

namespace mmazur.YnabApiClient.V1.Users;

public interface IYnabV1UserGetApiClient
{
    /// <summary>
    /// User info
    /// Returns authenticated user information
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserResponse?> GetAsync(CancellationToken cancellationToken = default);
}