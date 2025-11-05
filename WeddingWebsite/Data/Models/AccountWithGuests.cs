using WeddingWebsite.Models.Accounts;

namespace WeddingWebsite.Data.Models;

public class AccountWithGuests(IEnumerable<Guest> guests, bool hasLoggedIn) : Account
{
    public IEnumerable<Guest> Guests { get; } = guests;
    public bool HasLoggedIn { get; } = hasLoggedIn;
}