using WeddingWebsite.Data.Models;
using WeddingWebsite.Models.Rsvp;

namespace WeddingWebsite.Services;

public interface IRsvpService
{
    bool SubmitRsvp(string guestId, bool isAttending, IReadOnlyList<string?> data);
    IEnumerable<RsvpResponse> GetAllRsvps(bool isAttending, RsvpQuestions questions);
    RsvpResponse? GetRsvp(string guestId, RsvpQuestions yesQuestions, RsvpQuestions noQuestions);
    RsvpResponseData? GetRsvpBasic(string guestId);
    void DeleteRsvp(string guestId);
    bool EditRsvp(string guestId, bool isAttending, IReadOnlyList<string?> data);
}