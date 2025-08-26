using WeddingWebsite.Models;

namespace WeddingWebsite.Data;

public record Account(
    string Id,
    string Email,
    UserPrivilege Privilege,
    IEnumerable<Guest> Guests
);