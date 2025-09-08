// ReSharper disable InconsistentNaming

namespace mmazur.YnabApiClient.V1.Models.Categories;

public enum GoalType
{
    /// <summary>
    /// Target Category Balance
    /// </summary>
    TB,

    /// <summary>
    /// Target Category Balance by Date
    /// </summary>
    TBD,

    /// <summary>
    /// Monthly Funding
    /// </summary>
    MF,

    /// <summary>
    /// Plan Your Spending
    /// </summary>
    NEED,

    DEBT,
}