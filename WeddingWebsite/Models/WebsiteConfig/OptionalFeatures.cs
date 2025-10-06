namespace WeddingWebsite.Models.WebsiteConfig;

/// <summary>
/// Note the constructor is parameterless to force you to name the features you want explicitly, e.g.
///
/// new OptionalFeatures {
///     Registry = new ActiveFeature()
/// }
/// </summary>
public class OptionalFeatures
{
    public IOptionalFeature Registry = new InactiveFeature();
}