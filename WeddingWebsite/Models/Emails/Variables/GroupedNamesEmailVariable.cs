using WeddingWebsite.Data.Models;
using WeddingWebsite.Models.Accounts;

namespace WeddingWebsite.Models.Emails.Variables;

public class GroupedNamesEmailVariable : EmailVariableWithGuestFilters
{
    public override string Pattern => "GROUPED_NAMES";
    public override string Example => "Bob and Alice Smith";
    public override string Description => "If multiple surnames, fallback to %FULL_NAMES%.";
    
    public override string GetValueGuests(IList<Guest> guests)
    {
        if (guests.GroupBy(g => g.Name.Last).Count() == 1 && guests.Count > 1)
        {
            if (guests.Count == 2)
            {
                return $"{guests.First().Name.First} and {guests.Last().Name.First} {guests.First().Name.Last}";
            }
            var allButLast = guests.Take(guests.Count - 1).Select(g => g.Name.First);
            var last = guests.Last().Name.First;
            return $"{string.Join(", ", allButLast)}, and {last} {guests.First().Name.Last}";
        }
        {
            return new FullNamesEmailVariable().GetValueGuests(guests);
        }
    }
}