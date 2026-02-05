using WeddingWebsite.Models.People;

namespace WeddingWebsite.Models.Rsvp;

/// <summary>
/// Encapsulates a response to the RSVP form. Note that the columns will depend on whether they are attending or not.
/// </summary>
public record RsvpResponse(
    string GuestId,
    Name GuestName,
    bool IsAttending,
    IDictionary<string, string?> DataByColumn,
    IDictionary<string, string> DataByQuestion
);