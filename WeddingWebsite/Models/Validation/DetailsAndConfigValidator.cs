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
    
    /// <summary>
    /// An error that leads to incorrect / misleading information, or severe and definitely undesired behaviour.
    /// These errors must still be recoverable i.e. the site should render without throwing.
    /// </summary>
    private void Error(string message) {
        validationIssues.Add(new ValidationIssue(ValidationIssueSeverity.Error, message));
    }
    
    /// <summary>
    /// An issue that seems weird, but may be valid. E.g. specifying data that's overridden by another setting.
    /// </summary>
    private void Warning(string message) {
        validationIssues.Add(new ValidationIssue(ValidationIssueSeverity.Warning, message));
    }
    
    /// <summary>
    /// Something worth flagging, but very unlikely to cause a problem.
    /// </summary>
    private void Info(string message) {
        validationIssues.Add(new ValidationIssue(ValidationIssueSeverity.Info, message));
    }
}