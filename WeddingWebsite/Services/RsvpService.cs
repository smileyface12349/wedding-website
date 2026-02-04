using Microsoft.AspNetCore.Authorization;
using WeddingWebsite.Data.Stores;

namespace WeddingWebsite.Services;

[Authorize]
public class RsvpService(IRsvpStore rsvpStore) : IRsvpService
{
    public bool SubmitRsvp(string guestId, bool isAttending, IReadOnlyList<string?> data)
    {
        return rsvpStore.SubmitRsvp(guestId, isAttending, data);
    }
}