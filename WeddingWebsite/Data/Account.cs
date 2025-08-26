namespace WeddingWebsite.Models;

public record Account(
    string Id,
    string Email,
    UserPrivilege Privilege,
    IEnumerable<Guest> Guests
);