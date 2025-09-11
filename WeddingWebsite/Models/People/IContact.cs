namespace WeddingWebsite.Models.People;

public interface IContact
{
    public string NameAndRole { get; }
    public ContactDetails ContactDetails { get; }
}