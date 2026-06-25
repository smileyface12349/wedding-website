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
    
    public IOptionalFeature Rsvp = new InactiveFeature();
    
    public IOptionalFeature LiftSharing = new InactiveFeature();
    public IOptionalFeature LiftSharingOfferLifts = new ActiveFeature();
    public IOptionalFeature LiftSharingBookLifts = new ActiveFeature();
    public IOptionalFeature LiftSharingRequestLifts = new ActiveFeature();
}