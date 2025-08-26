namespace WeddingWebsite.Models.People;

public record Fiance(
    string FirstName,
    string LastName,
    ContactDetails ContactDetails
) : IContactable;