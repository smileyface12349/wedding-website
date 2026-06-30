namespace WeddingWebsite.Models.LiftSharing;

public record SharedLiftWithBookings(
    string Id,
    string UserId,
    string? UserEmail,
    string Name,
    int Spaces,
    JourneyEndpoint Start,
    JourneyEndpoint End,
    IEnumerable<SharedLiftBooking> Bookings,
    string Notes = ""
) : ISharedLift
{
    public int AvailableSpaces => Spaces - Bookings.Count();
    public Journey Journey => new Journey(Start, End);
}