using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WeddingWebsite.Data.Models;
using WeddingWebsite.Data.Stores;
using WeddingWebsite.Models.Accounts;

namespace WeddingWebsite.Services;

[Authorize]
public class AccountService(IStore store) : IAccountService
{
    public IEnumerable<GuestWithId> GetOwnGuests(ClaimsPrincipal user)
    {
        return store.GetGuestsForUser(GetUserId(user));
    }
    
    public void Log(ClaimsPrincipal user, AccountLogType logType, string description, string? affectedUserId = null)
    {
        var affectedUser = affectedUserId ?? GetUserId(user);
        store.AddAccountLog(affectedUser, GetUserId(user), logType, description);
    }

    private string? GetUserIdOrNull(ClaimsPrincipal user)
    {
        var claim = user.FindFirst(ClaimTypes.NameIdentifier);
        return claim?.Value;
    }
    
    private string GetUserId(ClaimsPrincipal user)
    {
        var userId = GetUserIdOrNull(user);
        if (userId == null)
        {
            throw new InvalidOperationException("User ID claim is missing.");
        }

        return userId;
    }
}