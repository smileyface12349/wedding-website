using System.Security.Claims;
using WeddingWebsite.Data.Models;
using WeddingWebsite.Models.Accounts;

namespace WeddingWebsite.Services;

public interface IAccountService
{
    public IEnumerable<GuestWithId> GetOwnGuests(ClaimsPrincipal user);

    /// <summary>
    /// Log a new event relating to a user account.
    /// </summary>
    /// <param name="user">The currently logged in user.</param>
    /// <param name="logType">What type of event happened.</param>
    /// <param name="description">A short description of what happened with any extra info that may be useful.</param>
    /// <param name="affectedUserId">(Optional) Which user is affected by this action. Defaults to the logged in user.</param>
    public void Log(ClaimsPrincipal user, AccountLogType logType, string description, string? affectedUserId = null);
    
    void Log(string actorEmail, AccountLogType logType, string description, string? affectedUserId = null);
}