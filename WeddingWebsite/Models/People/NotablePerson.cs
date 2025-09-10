using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.People;

public record NotablePerson(
    Name Name,
    Role Role,
    IEnumerable<WebsiteSection> Content
) : IPerson
{
    /// <summary>
    /// Shorthand constructor for people that definitely won't be shown on any "meet the wedding party" sections etc.
    /// </summary>
    public NotablePerson (string firstName, string lastName, Role role) : this (new Name(firstName, lastName), role, []) {}
}