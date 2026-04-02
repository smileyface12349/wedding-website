using WeddingWebsite.Models.Accounts;

namespace WeddingWebsite.Data.Enums;

public static class AccountLogTypeEnumConverter
{
    public static int ToDatabaseInteger(this AccountLogType accountLogType)
    {
        return accountLogType switch
        {
            AccountLogType.LogIn => 0,
            AccountLogType.ChangePassword => 1,
            AccountLogType.ChangeEmail => 2,
            AccountLogType.ChangePermissions => 3,
            AccountLogType.DeleteGuest => 4,
            AccountLogType.RenameGuest => 5,
            AccountLogType.AddGuest => 6,
            AccountLogType.ChangeUserName => 7,
            AccountLogType.SubmitRsvp => 8,
            AccountLogType.DeleteRsvp => 9,
            AccountLogType.EditRsvp => 10,
            AccountLogType.ClaimRegistryItem => 11,
            AccountLogType.UnclaimRegistryItem => 12,
            AccountLogType.CompleteRegistryItem => 13,
            _ => throw new ArgumentOutOfRangeException(nameof(accountLogType), accountLogType, null)
        };
    }
    
    public static int AccountLogTypeToDatabaseInteger(AccountLogType accountLogType)
    {
        return accountLogType.ToDatabaseInteger();
    }
    
    public static AccountLogType DatabaseIntegerToAccountLogType(int accountLogType)
    {
        return accountLogType switch
        {
            0 => AccountLogType.LogIn,
            1 => AccountLogType.ChangePassword,
            2 => AccountLogType.ChangeEmail,
            3 => AccountLogType.ChangePermissions,
            4 => AccountLogType.DeleteGuest,
            5 => AccountLogType.RenameGuest,
            6 => AccountLogType.AddGuest,
            7 => AccountLogType.ChangeUserName,
            8 => AccountLogType.SubmitRsvp,
            9 => AccountLogType.DeleteRsvp,
            10 => AccountLogType.EditRsvp,
            11 => AccountLogType.ClaimRegistryItem,
            12 => AccountLogType.UnclaimRegistryItem,
            13 => AccountLogType.CompleteRegistryItem,
            _ => throw new ArgumentOutOfRangeException(nameof(accountLogType), accountLogType, null)
        };
    }
}