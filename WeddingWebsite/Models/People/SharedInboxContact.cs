using WeddingWebsite.Core;

namespace WeddingWebsite.Models.People;

public record SharedInboxContact(
    string Title,
    IEnumerable<Role> Recipients,
    ContactDetails ContactDetails
) : IContact
{
    public string NameAndRole => $"{Title} ({string.Join(", ", Recipients.Select(r => r.GetEnumDescription()))})";
}