using WeddingWebsite.Data.Models;
using WeddingWebsite.Models.Accounts;

namespace WeddingWebsite.Services;

public interface IAdminService
{
    void AddGuestToAccount(string userId, string firstName, string lastName);
    IEnumerable<AccountWithGuests> GetAllAccounts();
    IEnumerable<GuestWithId> GetGuestsForAccount(string userId);
    GuestWithId? GetGuest(string userId, string guestId);
    void RenameGuest(string guestId, string newFirstName, string newLastName);
    void DeleteGuest(string guestId);
    string? GetAccountIdFromGuestId(string guestId);
    IEnumerable<AccountLog> GetAccountLogs(string userId);
    IEnumerable<AccountLog> GetAllAccountLogs(int limit = 100);
}