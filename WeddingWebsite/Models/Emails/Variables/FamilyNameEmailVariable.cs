using WeddingWebsite.Data.Models;
using WeddingWebsite.Models.Accounts;

namespace WeddingWebsite.Models.Emails.Variables;

public class FamilyNameEmailVariable : EmailVariableWithGuestFilters
{
    public override string Pattern => "FAMILY_NAME";
    public override string Example => "Smith family";
    public override string Description => "If multiple surnames or one guest, fallback to %FIRST_NAMES%.";
    
    public override string GetValueGuests(IList<Guest> guests)
    {
        if (guests.GroupBy(g => g.Name.Last).Count() == 1 && guests.Count > 1)
        {
            return $"{guests.First().Name.Last} family";
        }
        {
            return new FirstNamesEmailVariable().GetValueGuests(guests);
        }
    }
}