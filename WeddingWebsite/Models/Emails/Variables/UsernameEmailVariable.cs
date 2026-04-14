using WeddingWebsite.Data.Models;

namespace WeddingWebsite.Models.Emails.Variables;

public class UsernameEmailVariable : EmailVariable
{
    public override string Pattern => "USERNAME";
    public override string Example => "bob123";
    public override string Description => "Username of the account.";
    
    public override string GetValue(AccountWithGuests account, EmailFilters filters, string args)
    {
        return account.UserName ?? "";
    }
}