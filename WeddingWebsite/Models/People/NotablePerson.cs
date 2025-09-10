namespace WeddingWebsite.Models.People;

public record NotablePerson(
    Name Name,
    Role Role
) : IPerson
{
    public NotablePerson (string firstName, string lastName, Role role) : this (new Name(firstName, lastName), role) {}
}