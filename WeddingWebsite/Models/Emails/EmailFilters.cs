using WeddingWebsite.Models.Accounts;

namespace WeddingWebsite.Models.Emails;

public record EmailFilters(
    NumGuestsFilter NumGuestsFilter = NumGuestsFilter.Any,
    RsvpStatusFilter RsvpStatusFilter = RsvpStatusFilter.Any,
    bool RsvpStatusMatchAll = false
)
{
    public bool GuestMatchesRsvpStatus(Guest guest)
    {
        switch (RsvpStatusFilter)
        {
            case RsvpStatusFilter.NotNo:
                return guest.Rsvp != RsvpStatus.No;
            case RsvpStatusFilter.No:
                return guest.Rsvp == RsvpStatus.No;
            case RsvpStatusFilter.Waiting:
                return guest.Rsvp == RsvpStatus.NotResponded;
            case RsvpStatusFilter.Yes:
                return guest.Rsvp == RsvpStatus.Yes;
        }

        return true;
    }
}