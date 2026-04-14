using WeddingWebsite.Data.Models;
using WeddingWebsite.Models.Accounts;

namespace WeddingWebsite.Models.Emails.Variables;

public class FirstNamesEmailVariable : EmailVariableWithGuestFilters
{
    public override string Pattern => "FIRST_NAMES";
    public override string Example => "Bob and Alice";
    public override string Description => "First names.";
    
    public override string GetValueGuests(IList<Guest> guests)
    {
        if (!guests.Any())
        {
            return "";
        }
        if (guests.Count == 1)
        {
            return guests.Single().Name.First;
        }
        if (guests.Count == 2)
        {
            return $"{guests.First().Name.First} and {guests.Last().Name.First}";
        } 
        var allButLast = guests.Take(guests.Count - 1).Select(g => g.Name.First);
        var last = guests.Last().Name.First;
        return $"{string.Join(", ", allButLast)}, and {last}";
    }
}