using WeddingWebsite.Data.Models;
using WeddingWebsite.Models;
using WeddingWebsite.Models.Accounts;

namespace WeddingWebsite.Data.Stores;

public interface IStore
{
    /// <summary>
    /// Retrieve all guests associated with a specific user. Each guest is associated with exactly one user.
    /// </summary>
    public IEnumerable<GuestWithId> GetGuestsForUser(string userId);
    
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
    public IEnumerable<GuestWithId> GetGuestsForAccount(string userId);
    
    /// <summary>
    /// Renames a guest identified by guestId. Restricted to Admin users.
    /// </summary>
    public void RenameGuest(string guestId, string newFirstName, string newLastName);

    /// <summary>
    /// Deletes a guest. Restricted to Admin users.
    /// </summary>
    public void DeleteGuest(string guestId);
    
    /// <summary>
    /// Finds the account ID containing this particular guest
    /// </summary>
    public string? GetAccountIdFromGuestId(string guestId);
    
    /// <summary>
    /// Add log message to an account.
    /// </summary>
    public void AddAccountLog(string affectedUserId, string actorId, AccountLogType logType, string description);
    
    /// <summary>
    /// Get user id from their username
    /// </summary>
    public string? GetUserIdByUserName(string username);

    /// <summary>
    /// Get all logs affecting a particular account, regardless of who performed the action.
    /// </summary>
    public IEnumerable<AccountLog> GetAccountLogs(string userId);
}