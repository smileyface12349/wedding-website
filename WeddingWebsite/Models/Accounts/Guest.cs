using WeddingWebsite.Models.People;

namespace WeddingWebsite.Models.Accounts;

public record Guest(
    Name Name,
    RsvpStatus Rsvp = RsvpStatus.NotResponded
) : IPerson
{
    public Role Role => Role.Unknown;
}