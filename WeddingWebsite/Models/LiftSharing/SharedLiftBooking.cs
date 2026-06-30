using WeddingWebsite.Data.Models;

namespace WeddingWebsite.Models.LiftSharing;

public record SharedLiftBooking(
    string UserId,
    string UserEmail,
    string Name,
    DateTime BookedAt,
    string? GuestId = null
);