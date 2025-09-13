namespace WeddingWebsite.Models.People;

public record WhatsApp(string Number) : IContactMethod
{
    public string Type => "WhatsApp";
    public string Text => Number;
    public string? Link => null;
}