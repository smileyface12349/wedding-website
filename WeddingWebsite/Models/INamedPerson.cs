namespace WeddingWebsite.Models;

public interface INamedPerson
{
    public string FirstName { get; }
    public string LastName { get; }
    public string FullName => $"{FirstName} {LastName}";
}