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
            _ => throw new ArgumentOutOfRangeException(nameof(accountLogType), accountLogType, null)
        };
    }
}