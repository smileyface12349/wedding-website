using WeddingWebsite.Data.Models;

namespace WeddingWebsite.Models.Emails.Variables;

public class EmailEmailVariable : EmailVariable
{
    public override string Pattern => "EMAIL";
    public override string Example => "bob@example.com";
    public override string Description => "Recipient email address.";
    
    public override string GetValue(AccountWithGuests account, EmailFilters filters, string args)
    {
        return account.Email ?? "";
    }
}