using WeddingWebsite.Models.People;

namespace WeddingWebsite.Models;

public record Guest(
    Name Name,
    RsvpStatus Rsvp = RsvpStatus.NotResponded
) : IPerson
{
    public Role Role => Role.Unknown;
}