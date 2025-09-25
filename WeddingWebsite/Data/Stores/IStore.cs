using WeddingWebsite.Data.Models;
using WeddingWebsite.Models;

namespace WeddingWebsite.Data.Stores;

public interface IStore
{
    /// <summary>
    /// Retrieve all guests associated with a specific user. Each guest is associated with exactly one user.
    /// </summary>
    public IEnumerable<GuestResponse> GetGuestsForUser(string userId);
    
    /// <summary>
    /// Adds a new guest to the specified user's account. Restricted to Admin users.
    /// </summary>
    public void AddGuestToAccount(string userId, string firstName, string lastName);

    /// <summary>
    /// Retrieves all registered accounts along with their guests.
    /// </summary>
    public IEnumerable<AccountWithGuests> GetAllAccounts();

    /// <summary>
    /// Gets all guests associated with a specific account.
    /// </summary>
    public IEnumerable<Guest> GetGuestsForAccount(string userId);
}