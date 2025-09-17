namespace WeddingWebsite.Models.People;

public interface IContactMethod
{
    public string Type { get; }
    public string Text { get; }
    public string? Link { get; }
}