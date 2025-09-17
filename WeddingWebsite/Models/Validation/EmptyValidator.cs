using WeddingWebsite.Models.WebsiteConfig;
using WeddingWebsite.Models.WeddingDetails;

namespace WeddingWebsite.Models.Validation;

/// <summary>
/// Use this validator to disable all validation issues (at your own risk!)
/// </summary>
public class EmptyValidator: IDetailsAndConfigValidator
{
    public IEnumerable<ValidationIssue> Validate(IWeddingDetails details, IWebsiteConfig config) {
        return [];
    }
}