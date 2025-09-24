using System.Security.Claims;
using WeddingWebsite.Data.Models;

namespace WeddingWebsite.Services;

public interface IRsvpService
{
    public IEnumerable<GuestResponse> GetOwnGuests(ClaimsPrincipal user);
}