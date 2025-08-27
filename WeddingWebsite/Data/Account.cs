using Microsoft.AspNetCore.Identity;
using WeddingWebsite.Models;

namespace WeddingWebsite.Data;

public class Account(
    IEnumerable<Guest> Guests
) : IdentityUser
{
    public Account(): this(new List<Guest>())
    {
    }
}