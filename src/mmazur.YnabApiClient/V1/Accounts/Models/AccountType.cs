namespace mmazur.YnabApiClient.V1.Accounts.Models;

/// <summary>
/// The type of account
/// </summary>
public enum AccountType
{
    Checking,
    Savings,
    Cash,
    CreditCard,
    LineOfCredit,
    OtherAsset,
    OtherLiability,
    Mortgage,
    AutoLoan,
    StudentLoan,
    PersonalLoan,
    MedicalDebt,
    OtherDebt,
}