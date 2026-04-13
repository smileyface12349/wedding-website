using WeddingWebsite.Data.Models;
using WeddingWebsite.Models.Accounts;

namespace WeddingWebsite.Models.Emails.Variables;

public class FullNamesEmailVariable : EmailVariableWithGuestFilters
{
    public override string Pattern => "FULL_NAMES";
    public override string Example => "Bob Smith and Alice Smith";
    public override string Description => "Full names.";
    
    public override string GetValueGuests(IList<Guest> guests)
    {
        if (!guests.Any())
        {
            return "";
        }
        if (guests.Count == 1)
        {
            return guests.Single().Name.Full;
        }
        if (guests.Count == 2)
        {
            return $"{guests.First().Name.Full} and {guests.Last().Name.Full}";
        } 
        var allButLast = guests.Take(guests.Count - 1).Select(g => g.Name.Full);
        var last = guests.Last().Name.Full;
        return $"{string.Join(", ", allButLast)}, and {last}";
    }
}