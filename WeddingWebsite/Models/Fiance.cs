namespace WeddingWebsite.Models;

public record Fiance(
    string FirstName,
    string LastName,
    ContactDetails ContactDetails
) : IContactable;