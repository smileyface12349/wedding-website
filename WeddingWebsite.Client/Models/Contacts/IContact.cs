namespace WeddingWebsite.Client.Models.Contacts;

public interface IContact
{
    public string NameAndRole { get; }
    public ContactDetails ContactDetails { get; }
}