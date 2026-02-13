namespace WeddingWebsite.Models.Rsvp;

/// <summary>
/// Contains a place to store a piece of data in a response to RSVP form. Id must be between 1 and 20 - there are
/// exactly 20 boxes to store the data in. It's really important that this isn't changed after RSVPs are opened.
/// The display name is used for your benefit on the admin site within the guests table - you can sort and filter by
/// each column. If you leave it as null, it won't be shown on this table but can still be viewed when looking at
/// individual guests. If you have lots of questions, you should only give display names to the most important ones.
/// </summary>
public record RsvpDataColumn(int Id, string? DisplayName);