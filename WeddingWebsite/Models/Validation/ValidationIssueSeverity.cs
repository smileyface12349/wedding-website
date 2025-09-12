namespace WeddingWebsite.Models.Validation;

public enum ValidationIssueSeverity
{
    /// <summary>
    /// An issue that leads to displaying incorrect / misleading information, or none at all, and requires attention.
    /// All issues must be recoverable, and unaffected sections should still display properly without throwing.
    /// </summary>
    Error,
    
    /// <summary>
    /// Something that seems weird, but may be valid. E.g. specifying data that's overridden by another setting.
    /// </summary>
    Warning,
    
    /// <summary>
    /// Something worth mentioning as it may be unintuitive, but not a problem that needs fixing.
    /// </summary>
    Info
}