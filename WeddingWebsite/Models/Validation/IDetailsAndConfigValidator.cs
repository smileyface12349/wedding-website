using WeddingWebsite.Client.Config;
using WeddingWebsite.Models.WeddingDetails;

namespace WeddingWebsite.Models.Validation;

public interface IDetailsAndConfigValidator
{
    public IEnumerable<ValidationIssue> Validate(IWeddingDetails details, IWebsiteConfig config);
}