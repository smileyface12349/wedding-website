namespace WeddingWebsite.Models;

/// <summary>
/// A person with full name and contact details.
/// Note the contact details may be null.
/// </summary>
public interface IContactable : INamedPerson
{
    public ContactDetails ContactDetails { get; }
}