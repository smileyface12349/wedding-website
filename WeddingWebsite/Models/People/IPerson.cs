using WeddingWebsite.Client.Models.People;

namespace WeddingWebsite.Models.People;

public interface IPerson
{
    public Name Name { get; }
    public Role Role { get; }
}