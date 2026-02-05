using WeddingWebsite.Models.People;

namespace WeddingWebsite.Data.Models;

/// <summary>
/// A simple record to store a guest's RSVP data. Does not make any effort to match up columns to questions.
/// </summary>
public record RsvpResponseData(
    string GuestId,
    Name GuestName,
    bool IsAttending,
    IReadOnlyList<string?> Data
);