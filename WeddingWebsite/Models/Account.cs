namespace WeddingWebsite.Models;

public record Account(
    string Id,
    string Email,
    StoredPassword Password,
    UserPrivilege Privilege,
    IEnumerable<Guest> Guests
);