namespace WeddingWebsite.Models.People;

public record EmailAddress(string Email) : IContactOption
{
    public string Type => "Email";
    public string Text => Email;
    public string? Link => $"mailto:{Email}";
}