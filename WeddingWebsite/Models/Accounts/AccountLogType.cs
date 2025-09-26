using System.ComponentModel;

namespace WeddingWebsite.Models.Accounts;

public enum AccountLogType
{
    [Description("Log in")]
    LogIn,
    
    [Description("Change password")]
    ChangePassword,
}