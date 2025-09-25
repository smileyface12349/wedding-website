using Microsoft.AspNetCore.Identity;
using WeddingWebsite.Models;

namespace WeddingWebsite.Data;

/// <summary>
/// The bare minimum necessary information for the authentication system. Guests are not fetched as standard, and are
/// instead in <see cref="Models.AccountWithGuests"/>
/// </summary>
public class Account : IdentityUser;