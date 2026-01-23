using Microsoft.AspNetCore.Components;

namespace WeddingWebsite.Models.ConfigInterfaces;

/// <summary>
/// Customise all user-facing strings, either into a different language or just different wording.
/// This only applies to stuff that your guests will see, so admin pages and error messages are excluded.
/// This may be added in future, but isn't a priority.
/// Occasionally, something is missed. If so, feel free to make a PR or an issue!
/// </summary>
public interface IStringProvider
{
    string Month { get; }
    string Week { get; }
    string Day { get; }
    string Hour { get; }
    string Minute { get; }
    string Second { get; }
    
    string Yes { get; }
    string No { get; }
    string View { get; }
    string YouHaveUnsavedChanges { get; }
    string Undo { get; }
    string Submit { get; }
    string Cancel { get; }
    
    string WebsiteTitle { get; }
    string MyAccount { get; }
    string Logout { get; }
    string Login { get; }
    string Username { get; }
    string Password { get; }
    string RememberMe { get; }
    string ForgotPasswordContact(string contactMethod);
    
    string YourAccount { get; }
    string EmailAddress { get; }
    string CurrentPassword { get; }
    string OldPassword { get; }
    string NewPassword { get; }
    string ConfirmPassword { get; }
    string IsMyPasswordSafe { get; }
    string ChangePassword { get; }
    string Guests { get; }
    string RsvpNotYetOpen { get; }
    string AccountSharedWithGuests(int guestCount);
    string Rsvp { get; }
    string PlusOnesDescription { get; }
    string NoGuestsWarning(string? contactMethod);
    
    string Gallery { get; }
    
    string Home { get; }
    
    string Accommodation { get; }
    string Address { get; }
    string Distance { get; }
    string DriveFromVenue(int minutes);
    string ApproximatePrice { get; }
    string VisitWebsite { get; }
    string GoogleMaps { get; }
    string Name { get; }
    string Price { get; }
    string Link { get; }
    string NumMinutesShort(int minutes);
    string OtherOptions { get; }
    
    string ContactUs { get; }
    string ContactUsEnterCategory { get; }
    string CategoryOfEnquiry { get; }
    string ContactUsEnterUrgency { get; }
    string SuggestedContacts { get; }
    string NoContactsBecauseNoCategory { get; }
    string NoContactsMatched { get; }
    
    string Directions { get; }
    
    string DressCode { get; }
    MarkupString DressCodeQuestions(string name, string? contactMethod);
    
    string HowWeMet { get; }
    
    string MeetTheWeddingParty { get; }
    
    string OrderOfTheDay { get; }
    
    string VenueShowcase { get; }
    
    string Registry { get; }
    string RegistryDescription1 { get; }
    string RegistryDescription2 { get; }
    string SortBy { get; }
    string Default { get; }
    string PriceLowToHigh { get; }
    string PriceHighToLow { get; }
    string Filters { get; }
    string ItemsYouHaveClaimed { get; }
    string Completed { get; }
    string Pending { get; }
    string OtherRegistryItems { get; }
    string Claimed { get; }
    string Available { get; }
    string TheRegistryIsEmpty { get; }
    string NoItemsMatchFilters { get; }
    
    string ItemNotFound { get; }
    string BackToRegistry { get; }
    string QuantityClaimed(int claimed, int total);
    string PurchaseOptions { get; }
    string DoNotPurchaseBeforeClaiming { get; }
    string DoNotPurchaseBeforeDetails { get; }
    string CurrencySymbol { get; }
    string CurrencyAmount(decimal amount);
    string DeliveryCost(decimal cost);
    string ItemPurchased { get; }
    string ThankYouForGift { get; }
    MarkupString QuantityPurchased(int quantity);
    MarkupString PurchaseMethod(string purchaseMethod);
    MarkupString DeliveryAddress(string? address);
    string RegistryClaimedContact(string? contactMethod);
    string Notes { get; }
    string NotesDescription { get; }
    string NotesPlaceholder { get; }
    string SaveNotes { get; }
    string SelectPurchaseMethod { get; }
    MarkupString SelectedQuantity(int quantity);
    string SelectPurchaseMethodDescription { get; }
    string SelectDeliveryAddress { get; }
    MarkupString SelectedPurchaseMethod(string purchaseMethod);
    string SelectDeliveryAddressDescription { get; }
    string BringOnTheDay { get; }
    string ItemReadyToPurchase { get; }
    MarkupString SelectedDeliveryAddress(string? address);
    string ItemReadyToPurchaseDescription { get; }
    string GoToPurchasePage { get; }
    MarkupString CustomPurchaseInstructions(string? instructions);
    string MarkAsCompleted { get; }
    string UnclaimDescription { get; }
    string Unclaim { get; }
    string ItemClaimed { get; }
    string ItemClaimedDescription { get; }
    string ClaimThisItem { get; }
    string ClaimThisItemDescription { get; }
    string Quantity { get; }
    string Claim { get; }

    string RegistryInactiveDescription(string description);
    
    string CreatedBy { get; }
    string SourceCodeOn { get; }
    string GitHub { get; }
}