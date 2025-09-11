namespace WeddingWebsite.Models.People;

public interface IContactOption
{
    public string Type { get; }
    public string Text { get; }
    public string? Link { get; }
}