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
    
    /// <summary>
    /// Contact details but no blurb
    /// </summary>
    public NotablePerson (Name name, Role role, ContactDetails contactDetails) : this (name, role, contactDetails, []) {}
    
    /// <summary>
    /// No contact details but has blurb for "meet the wedding party"
    /// </summary>
    public NotablePerson (Name name, Role role, IEnumerable<WebsiteSection> content, IWebsiteElement? media = null)
        : this (name, role, new(), content, media) {}

    public string NameAndRole => $"{Name} ({Role.GetEnumDescription()})";
}