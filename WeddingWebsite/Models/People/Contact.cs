namespace WeddingWebsite.Models.People;

/// <summary>
/// Someone to display in a list of contacts
/// </summary>
/// <param name="Role">E.g. "Best Man" or "Father of the Bride"</param>
/// <param name="ReasonForContacting">E.g. "if you're no longer able to come" or "for enquiries about logistics" </param>
public record Contact(
    string FirstName,
    string LastName,
    string Role,
    ContactDetails ContactDetails,
    string? ReasonForContacting
) : IContactable
{
    public Contact(IContactable contactable, string role, string? reason) : this(contactable.FirstName, contactable.LastName, role, contactable.ContactDetails, reason) {}
}