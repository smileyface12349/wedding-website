using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WeddingWebsite.Data.Models;
using WeddingWebsite.Data.Stores;

namespace WeddingWebsite.Services;

[Authorize]
public class RsvpService(IStore store) : IRsvpService
{
    public IEnumerable<GuestWithId> GetOwnGuests(ClaimsPrincipal user)
    {
        var claim = user.FindFirst(ClaimTypes.NameIdentifier);
        var userId = claim.Value;
        return store.GetGuestsForUser(userId);
    }
}