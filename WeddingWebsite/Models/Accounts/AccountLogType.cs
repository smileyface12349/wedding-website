using System.ComponentModel;

namespace WeddingWebsite.Models.Accounts;

public enum AccountLogType
{
    [Description("Log in")]
    LogIn,
    
    [Description("Change password")]
    ChangePassword,
    
    [Description("Change email")]
    ChangeEmail,
    
    [Description("Change permissions")]
    ChangePermissions,
    
    [Description("Delete guest")]
    DeleteGuest,
    
    [Description("Rename guest")]
    RenameGuest
}