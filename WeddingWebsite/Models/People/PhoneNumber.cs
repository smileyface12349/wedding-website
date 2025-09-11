namespace WeddingWebsite.Models.People;

public record PhoneNumber(string Number) : IContactOption
{
    public string Text => Number;
    public string? Link => null;
}