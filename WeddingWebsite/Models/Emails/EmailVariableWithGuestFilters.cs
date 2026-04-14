using WeddingWebsite.Data.Models;
using WeddingWebsite.Models.Accounts;

namespace WeddingWebsite.Models.Emails;

public abstract class EmailVariableWithGuestFilters : EmailVariable
{
    /// <summary>
    /// Supplies the already filtered guests to your custom method.
    /// </summary>
    public abstract string GetValueGuests(IList<Guest> guests);
    
    /// <summary>
    /// Filter the guests and then call base class method to get the value.
    /// </summary>
    public override string GetValue(AccountWithGuests account, EmailFilters filters, string args)
    {
        switch (args.ToUpper())
        {
            case "ALL":
                return GetValueGuests(account.Guests.ToList());
            case "RSVP_YES":
                var rsvpYesGuests = account.Guests.Where(g => g.Rsvp == RsvpStatus.Yes);
                return GetValueGuests(rsvpYesGuests.ToList());
            case "RSVP_NO":
                var rsvpNoGuests = account.Guests.Where(g => g.Rsvp == RsvpStatus.No);
                return GetValueGuests(rsvpNoGuests.ToList());
            case "RSVP_WAITING":
                var rsvpWaitingGuests = account.Guests.Where(g => g.Rsvp == RsvpStatus.NotResponded);
                return GetValueGuests(rsvpWaitingGuests.ToList());
            default:
                var matchingGuests = account.Guests.Where(filters.GuestMatchesRsvpStatus);
                return GetValueGuests(matchingGuests.ToList());
        }
    }
}