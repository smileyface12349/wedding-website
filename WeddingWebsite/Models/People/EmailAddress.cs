using WeddingWebsite.Client.Models.Contacts;

namespace WeddingWebsite.Models.People;

public record EmailAddress(string Email) : IContactMethod
{
    public string Type => "Email";
    public string Text => Email;
    public string? Link => $"mailto:{Email}";
}