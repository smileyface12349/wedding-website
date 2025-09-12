using WeddingWebsite.Models.WebsiteConfig;
using WeddingWebsite.Models.WeddingDetails;

namespace WeddingWebsite.Models.Validation;

public class DetailsAndConfigValidator: IDetailsAndConfigValidator
{
    private IList<ValidationIssue> validationIssues = [];
    
    public IEnumerable<ValidationIssue> Validate(IWeddingDetails details, IWebsiteConfig config) {
        validationIssues = [];
        

        return validationIssues;
    }
}