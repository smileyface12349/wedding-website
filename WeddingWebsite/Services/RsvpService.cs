using Microsoft.AspNetCore.Authorization;
using WeddingWebsite.Data.Models;
using WeddingWebsite.Data.Stores;
using WeddingWebsite.Models.Rsvp;

namespace WeddingWebsite.Services;

[Authorize]
public class RsvpService(IRsvpStore rsvpStore) : IRsvpService
{
    public bool SubmitRsvp(string guestId, bool isAttending, IReadOnlyList<string?> data)
    {
        return rsvpStore.SubmitRsvp(guestId, isAttending, data);
    }
    
    public IEnumerable<RsvpResponse> GetAllRsvps(bool isAttending, RsvpQuestions questions)
    {
        var rsvps = rsvpStore.GetAllRsvps();
        return rsvps.Where(rsvp => rsvp.IsAttending == isAttending).Select(rsvp =>
        {
            var data = new Dictionary<string, string?>();
            foreach (var column in questions.GetAllColumns().Where(col => col.DisplayName != null))
            {
                var value = rsvp.Data.ElementAtOrDefault(column.Id);
                data[column.DisplayName!] = value;
            }
            return new RsvpResponse(rsvp.GuestId, rsvp.GuestName, rsvp.IsAttending, data);
        });
    }
}