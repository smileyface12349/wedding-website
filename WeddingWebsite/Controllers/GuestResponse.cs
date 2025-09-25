using WeddingWebsite.Data.Enums;
using WeddingWebsite.Data.Models;
using WeddingWebsite.Models;
using WeddingWebsite.Models.People;

namespace WeddingWebsite.Controllers;

public record GuestResponse(string GuestId, string FirstName, string LastName, int Rsvp)
{
    public GuestWithId ToGuestObject()
    {
        return new GuestWithId(
            GuestId,
            new Name(FirstName, LastName),
            RsvpStatusEnumConverter.DatabaseIntegerToRsvpStatus(Rsvp)
        );
    }
}