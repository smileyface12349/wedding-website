using WeddingWebsite.Models.ConfigInterfaces;
using WeddingWebsite.Models.WebsiteConfig;

namespace WeddingWebsite.Models.Validation;

public interface IDetailsAndConfigValidator
{
    public IEnumerable<ValidationIssue> Validate(IWeddingDetails details, IWebsiteConfig config);
}