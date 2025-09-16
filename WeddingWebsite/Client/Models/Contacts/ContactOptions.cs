namespace WeddingWebsite.Client.Models.Contacts;

public record ContactOptions
{
    /// <summary>
    /// Null is a special state that matches any reason.
    /// </summary>
    private IEnumerable<ContactReason>? Reasons;
    public IEnumerable<IContactMethod> Methods { get; }
    
    public ContactOptions(IEnumerable<ContactReason>? reasons, IEnumerable<IContactMethod> methods) {
        Reasons = reasons;
        Methods = methods;
    }
    
    public bool MatchesReason(ContactReason reason) {
        return Reasons == null || Reasons.Contains(reason);
    }
}