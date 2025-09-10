using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.People;

public record NotablePerson(
    Name Name,
    Role Role,
    IEnumerable<WebsiteSection> Content,
    IWebsiteElement? Media = null
) : IPerson
{
    /// <summary>
    /// Shorthand constructor if you don't want any extra info on the "meet the wedding party" section, or if this
    /// person is not on that section.
    /// </summary>
    public NotablePerson (string firstName, string lastName, Role role) : this (new Name(firstName, lastName), role, []) {}
}