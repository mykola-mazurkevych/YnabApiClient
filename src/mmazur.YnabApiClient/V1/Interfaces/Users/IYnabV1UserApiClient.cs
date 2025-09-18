using mmazur.YnabApiClient.V1.Models.Users;

namespace mmazur.YnabApiClient.V1.Interfaces.Users;

public interface IYnabV1UserApiClient
{
    /// <summary>
    /// User info
    /// Returns authenticated user information
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserResponse?> GetAsync(CancellationToken cancellationToken = default);
}