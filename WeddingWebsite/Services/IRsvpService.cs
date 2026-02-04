namespace WeddingWebsite.Services;

public interface IRsvpService
{
    bool SubmitRsvp(string guestId, bool isAttending, IReadOnlyList<string?> data);
}