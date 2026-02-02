namespace WeddingWebsite.Data.Models;

/// <summary>
/// A basic record for the stored RSVP data, that makes no effort to match up questions to answers.
/// RsvpData will have length 20.
/// </summary>
public record RsvpResponseData(
    bool IsAttending,
    IReadOnlyList<string?> RsvpData
);