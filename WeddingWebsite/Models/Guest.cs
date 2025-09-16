using WeddingWebsite.Client.Models.Contacts;
using WeddingWebsite.Models.People;

namespace WeddingWebsite.Models;

public record Guest(
    ContactDetails ContactDetails,
    Name Name,
    RSPVStatus? Rspv = null
) : IPerson
{
    public Role Role => Role.Unknown;
}