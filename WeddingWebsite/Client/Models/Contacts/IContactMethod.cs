namespace WeddingWebsite.Client.Models.Contacts;

public interface IContactMethod
{
    public string Type { get; }
    public string Text { get; }
    public string? Link { get; }
}