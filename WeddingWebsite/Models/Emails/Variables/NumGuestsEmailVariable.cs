using WeddingWebsite.Data.Models;
using WeddingWebsite.Models.Accounts;

namespace WeddingWebsite.Models.Emails.Variables;

public class NumGuestsEmailVariable : EmailVariableWithGuestFilters
{
    public override string Pattern => "NUM_GUESTS";
    public override string Example => "2";
    public override string Description => "Number of guests on the account.";
    
    public override string GetValueGuests(IList<Guest> guests)
    {
        return guests.Count.ToString();
    }
}