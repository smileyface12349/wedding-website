using WeddingWebsite.Core;
using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.People;

public record NotablePerson(
    Name Name,
    Role Role,
    ContactDetails ContactDetails,
    IEnumerable<WebsiteSection> Content,
    IWebsiteElement? Media = null
) : IPerson, IContact
{
    /// <summary>
    /// No contact details, no blurb for "meet the wedding party"
    /// </summary>
    public NotablePerson (Name name, Role role) : this (name, role, new(), []) {}

    public string NameAndRole => $"{Name} ({Role.GetEnumDescription()}";
}