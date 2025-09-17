using WeddingWebsite.Core;

namespace WeddingWebsite.Models.People;

public record Contact(
    Name Name,
    Role Role,
    ContactDetails ContactDetails,
    string ReasonForContacting = "",
    bool Emphasise = false
) : IContact
{
    public Contact(IPerson person, ContactDetails contactDetails, string reasonForContacting = "", bool emphasise = false)
        : this(person.Name, person.Role, contactDetails, reasonForContacting, emphasise) { }

    public string NameAndRole => $"{Name.Full} ({Role.GetEnumDescription()})";
}