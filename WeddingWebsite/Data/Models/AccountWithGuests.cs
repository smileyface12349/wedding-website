using WeddingWebsite.Models.Accounts;

namespace WeddingWebsite.Data.Models;

public class AccountWithGuests(IEnumerable<Guest> guests) : Account
{
    public IEnumerable<Guest> Guests { get; } = guests;
}