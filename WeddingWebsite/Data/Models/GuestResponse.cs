using WeddingWebsite.Data.Enums;
using WeddingWebsite.Models;
using WeddingWebsite.Models.People;

namespace WeddingWebsite.Data.Models;

public record GuestResponse(string AccountId, string GuestId, string FirstName, string LastName, int Rsvp)
{
    public Guest ToGuestObject()
    {
        return new Guest(
            new Name(FirstName, LastName),
            RsvpStatusEnumConverter.DatabaseIntegerToRsvpStatus(Rsvp)
        );
    }
}