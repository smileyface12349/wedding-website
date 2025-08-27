using Microsoft.AspNetCore.Authorization;
using WeddingWebsite.Models.People;

namespace WeddingWebsite.Models.WeddingDetails;

/// <summary>
/// Used to test authorization - should not be accessible to unauthenticated users
/// </summary>

[Authorize]
public class SecretWeddingDetails : SampleWeddingDetails
{
    public new Fiance Groom { get; } = new Fiance("Spongebob", "Squarepants", new ContactDetails(null, null));
}