using Microsoft.AspNetCore.Components;
using WeddingWebsite.Models.Registry;

namespace WeddingWebsite.Models.ConfigInterfaces;

/// <summary>
/// Customise all user-facing strings, either into a different language or just different wording. This generally only
/// applies to stuff that your guests will see, so admin-only pages are usually excluded from the string provider.
/// Occasionally, something is missed. If you discover a guest-facing string that is not configurable in here, please
/// create an issue and I will fix it!
/// </summary>
public interface IStringProvider
{
    string WebsiteTitle { get; }
    string PageTitle(string specificTitle);
    
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
    
    string RsvpInactiveDescription(string description);
    string RsvpChooseGuest { get; }
    string ViewRsvp { get; }
    string RsvpThankYou { get; }
    string RsvpThankYouDescription(string? contactMethod);
    string SubmitAnotherRsvp { get; }
    string BackToHome { get; }
    string PleaseRsvpByDeadline(string deadline);
    string RsvpDeadlinePassed { get; }
    MarkupString YouSeemABitLost { get; }
    string RsvpAlreadySubmitted(string? contactMethod);
    string RsvpFormDescription { get; }
    string RsvpFormDescriptionContact(string? contactMethod);
    string RsvpAttendanceQuestion { get; }
    string RsvpLongYes { get; }
    string RsvpLongNo { get; }
    string? RsvpYesDescription { get; }
    string? RsvpNoDescription { get; }
    string AreYouSure { get; }
    string RsvpConfirmDescription { get; }
    string RsvpSomethingWentWrong { get; }
    string RsvpTooLong(string? contactMethod);
    
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
    MarkupString FulfillmentMethod(FulfillmentMethod fulfillmentMethod);
    MarkupString DeliveryAddress(string? address);
    MarkupString BankDetails(string? bankDetails);
    string RegistryClaimedContact(string? contactMethod);
    string Notes { get; }
    string NotesDescription { get; }
    string NotesPlaceholder { get; }
    string SaveNotes { get; }
    string SelectFulfillmentMethod { get; }
    string NoFulfillmentMethodsDescription { get; }
    MarkupString SelectedQuantity(int quantity);
    string SelectFulfillmentMethodDescription { get; }
    string SelectDeliveryAddress { get; }
    string SelectBankDetails { get; }
    MarkupString SelectedFulfillmentMethod(FulfillmentMethod? fulfillmentMethod);
    string SelectDeliveryAddressDescription { get; }
    string SelectBankDetailsDescription { get; }
    string ItemReadyToPurchase { get; }
    MarkupString SelectedDeliveryAddress(string? address);
    MarkupString SelectedBankDetails(string? bankDetails);
    string ItemReadyToPurchaseDescription { get; }
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