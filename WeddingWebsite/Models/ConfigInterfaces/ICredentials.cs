using WeddingWebsite.Core.Emails;

namespace WeddingWebsite.Models.ConfigInterfaces;

public interface ICredentials
{
    public string GoogleMaps { get; }
    public EmailConfiguration EmailConfiguration { get; }
}