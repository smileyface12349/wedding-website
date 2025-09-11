namespace WeddingWebsite.Models.People;

public record EmailAddress(string Email) : IContactOption
{
    public string Text => Email;
    public string? Link => $"mailto:{Email}";
}