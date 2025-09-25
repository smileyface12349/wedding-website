using WeddingWebsite.Data.Models;
using WeddingWebsite.Models;

namespace WeddingWebsite.Services;

public interface IAdminService
{
    void AddGuestToAccount(string userId, string firstName, string lastName);
    IEnumerable<AccountWithGuests> GetAllAccounts();
    IEnumerable<GuestWithId> GetGuestsForAccount(string userId);
}