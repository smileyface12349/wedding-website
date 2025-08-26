namespace WeddingWebsite.Models;

public record Guest(
    ContactDetails ContactDetails,
    string FirstName,
    string LastName,
    RSPVStatus? Rspv
) : IContactable;