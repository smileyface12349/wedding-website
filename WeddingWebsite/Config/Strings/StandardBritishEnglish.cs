using Microsoft.AspNetCore.Components;
using WeddingWebsite.Core;
using WeddingWebsite.Models.ConfigInterfaces;
using WeddingWebsite.Models.Registry;

namespace WeddingWebsite.Config.Strings;

/// <summary>
/// British English, with a formal and polite tone that aims for brevity and clarity.
/// </summary>
public class StandardBritishEnglish : IStringProvider
{
    public string Month => "Month";
    public string Week => "Week";
    public string Day => "Day";
    public string Hour => "Hour";
    public string Minute => "Minute";
    public string Second => "Second";
    
    public string Yes => "Yes";
    public string No => "No";
    public string View => "View";
    public string YouHaveUnsavedChanges => "You have unsaved changes.";
    public string Undo => "Undo";
    public string Submit => "Submit";
    public string Cancel => "Cancel";
    
    public string WebsiteTitle => "Wedding Website";
    public string MyAccount => "My Account";
    public string Logout => "Logout";
    public string Login => "Log in";
    public string Username => "Username";
    public string Password => "Password";
    public string RememberMe => "Remember me";
    public string ForgotPasswordContact(string contactMethod) => "Forgot your password? Contact " + contactMethod + ".";
    
    public string YourAccount => "Your Account";
    public string EmailAddress => "Email Address";
    public string CurrentPassword => "Current Password";
    public string OldPassword => "Old Password";
    public string NewPassword => "New Password";
    public string ConfirmPassword => "Confirm Password";
    public string IsMyPasswordSafe => "Is my password safe?";
    public string ChangePassword => "Change Password";
    public string Guests => "Guests";
    public string RsvpNotYetOpen => "RSVPs are not yet open.";
    public string AccountSharedWithGuests(int guestCount) =>  $"This account is shared between {guestCount} guest{(guestCount != 1 ? "s" : "")}. Please share your login details with all of these guests.";
    public string Rsvp => "RSVP";
    public string PlusOnesDescription => "Unfortunately, we are unable to accommodate any extra +1's.";
    public string NoGuestsWarning(string? contactMethod) => $"Your account does not have any guests associated with it. If you think this is an error, please contact {contactMethod} as soon as possible.";

    public string Gallery => "Gallery";
    
    public string Home => "Home";
    
    public string Accommodation => "Accommodation";
    public string Address => "Address";
    public string Distance => "Distance";
    public string DriveFromVenue(int minutes) => $"{minutes} min drive from the venue.";
    public string ApproximatePrice => "Approximate Price";
    public string VisitWebsite => "Visit Website";
    public string GoogleMaps => "Google Maps";
    public string Name => "Name";
    public string Price => "Price";
    public string Link => "Link";
    public string NumMinutesShort(int minutes) => $"{minutes} min";
    public string OtherOptions => "Other Options";
    
    public string ContactUs => "Contact Us";
    public string ContactUsEnterCategory => "What is your enquiry about?";
    public string CategoryOfEnquiry => "Category of Enquiry";
    public string ContactUsEnterUrgency => "Is it urgent?";
    public string SuggestedContacts => "Suggested contacts";
    public string NoContactsBecauseNoCategory => "Choose a category of enquiry to see contacts.";
    public string NoContactsMatched => "No contacts found. Try a different search.";

    public string Directions => "Directions";

    public string DressCode => "Dress Code";
    public MarkupString DressCodeQuestions(string name, string? contactMethod) => (MarkupString) $"<b>Questions?</b> Contact {name} on {contactMethod}.";

    public string HowWeMet => "How We Met";

    public string MeetTheWeddingParty => "Meet the Wedding Party";

    public string OrderOfTheDay => "Order of the Day";

    public string VenueShowcase => "Venue Showcase";

    public string RsvpInactiveDescription(string description) => $"RSVPs are {description}.";
    public string RsvpChooseGuest => "Please choose which guest you would like to RSVP for.";
    public string ViewRsvp => "View RSVP";
    public string RsvpThankYou => "Thank you for submitting your RSVP.";
    public string RsvpThankYouDescription(string? contactMethod) => $"If you need to change anything in your RSVP form at a later date, please contact {contactMethod ?? "us"} and we will do our best to accommodate it.";
    public string SubmitAnotherRsvp => "Submit Another RSVP";
    public string BackToHome => "Back to Home";
    public string PleaseRsvpByDeadline(string deadline) => $"Please RSVP by {deadline}.";
    public string RsvpDeadlinePassed => "The RSVP deadline has now passed. Please RSVP as soon as possible.";
    public MarkupString YouSeemABitLost => (MarkupString) "You seem a bit lost. Why not head back to the <a href=\"/\">homepage</a>?";
    public string RsvpAlreadySubmitted(string? contactMethod) => $"As your RSVP has been submitted, it is read-only. If you need to make any changes, please contact {contactMethod ?? "us"} and we'll try our best to accommodate them.";
    public string RsvpFormDescription => "Please complete this form once per guest. Your answers will not be saved until you submit, after which you will be unable to make any changes.";
    public string RsvpFormDescriptionContact(string? contactMethod) => $"If you have any questions, please contact {contactMethod ?? "us"}.";
    public string RsvpAttendanceQuestion => "Will you be able to join us at our wedding?";
    public string RsvpLongYes => "Joyfully accept";
    public string RsvpLongNo => "Regretfully decline";
    public string? RsvpYesDescription => null;
    public string? RsvpNoDescription => null;
    public string AreYouSure => "Are you sure?";
    public string RsvpConfirmDescription => "Take a moment to double check all of your answers. After submitting, you will not be able to change them yourself.";
    public string RsvpSomethingWentWrong => "Something went wrong when submitting your RSVP. Maybe it already went through?";
    public string RsvpTooLong(string? contactMethod) => contactMethod == null ? "Got more to say? Let us know separately." : $"Got more to say? Let us know separately at {contactMethod}.";

    public string Registry => "Registry";
    public string RegistryDescription1 => "If you would like to give us a gift, this page contains some suggestions of things we'd like.";
    public string RegistryDescription2 => "Each item will direct you to an external website where you can purchase it. To avoid duplicates, please ensure that you claim an item before making a purchase.";
    public string SortBy => "Sort By";
    public string Default => "Default";
    public string PriceLowToHigh => "Price: Low to High";
    public string PriceHighToLow => "Price: High to Low";
    public string Filters => "Filters";
    public string ItemsYouHaveClaimed => "Items You've Claimed";
    public string Completed => "Completed";
    public string Pending => "Pending";
    public string OtherRegistryItems => "Other Registry Items";
    public string Claimed => "Claimed";
    public string Available => "Available";
    public string TheRegistryIsEmpty => "The registry is currently empty.";
    public string NoItemsMatchFilters => "There are no items matching the selected filters.";
    
    public string ItemNotFound => "Sorry, that item could not be found.";
    public string BackToRegistry => "Back to Registry";
    public string QuantityClaimed(int claimed, int total) => $"Quantity Claimed: {claimed}/{total}.";
    public string PurchaseOptions => "Purchase Options";
    public string DoNotPurchaseBeforeClaiming => "Please do not make a purchase before you have claimed the item.";
    public string DoNotPurchaseBeforeDetails => "Please finish selecting the details below before making a purchase.";
    public virtual string CurrencySymbol => "£";
    public string CurrencyAmount(decimal amount)=> $"{CurrencySymbol}{amount:F2}";
    public string DeliveryCost(decimal cost) => $"+{CurrencyAmount(cost)} delivery";
    public string ItemPurchased => "Item Purchased";
    public string ThankYouForGift => "Thank you so much for your gift!";
    public MarkupString QuantityPurchased(int quantity) => (MarkupString) $"Quantity purchased: <b>{quantity}</b>.";
    public MarkupString FulfillmentMethod(FulfillmentMethod fulfillmentMethod) => (MarkupString) $"Receive method: <b>{fulfillmentMethod.GetEnumDescription()}</b>.";
    public MarkupString DeliveryAddress(string? address)  => (MarkupString) $"Delivery address: <b>{address}</b>.";
    public MarkupString BankDetails(string? bankDetails)  => (MarkupString) $"Bank details: <b>{bankDetails}</b>.";
    public string RegistryClaimedContact(string? contactMethod) => $"Since this is now completed, you can no longer make any changes. If something went wrong, please contact {contactMethod}.";
    public string Notes => "Notes";
    public string NotesDescription => "If you'd like to leave a note, you can do so in the box below.";
    public string NotesPlaceholder => "Add a note visible to you and the website administrators (optional).";
    public string SaveNotes => "Save Notes";
    public string SelectFulfillmentMethod => "Select Fulfillment Method";
    public MarkupString SelectedQuantity(int quantity) => (MarkupString) $"Selected quantity: <b>{quantity}</b>.";
    public string SelectFulfillmentMethodDescription => "Please choose how you would like to give this item to us.";
    public string SelectDeliveryAddress => "Select Delivery Address";
    public string SelectBankDetails => "Select Bank Details";
    public MarkupString SelectedFulfillmentMethod(FulfillmentMethod? fulfillmentMethod) => (MarkupString) $"Selected receive method: <b>{fulfillmentMethod?.GetEnumDescription()}</b>.";
    public string SelectDeliveryAddressDescription => "Please choose which address you would like to send it to.";
    public string SelectBankDetailsDescription => "Please choose which bank account you would like to send the money to.";
    public string BringOnTheDay => "I'll bring it on the day";
    public string ItemReadyToPurchase => "Item Ready to Purchase";
    public MarkupString SelectedDeliveryAddress(string? address) => (MarkupString) $"Selected delivery address: <b>{address}</b>.";
    public MarkupString SelectedBankDetails(string? bankDetails) => (MarkupString) $"Selected bank details: <b>{bankDetails}</b>.";
    public string ItemReadyToPurchaseDescription => "Thank you. You can now purchase the item. Please mark it as completed once you are done.";
    public string MarkAsCompleted => "Mark as Completed (cannot be undone)";
    public string UnclaimDescription => "If you've changed your mind and you'd no longer like to buy this item, please unclaim it to make it available to others.";
    public string Unclaim => "Unclaim";
    public string ItemClaimed => "Item Already Claimed";
    public string ItemClaimedDescription => "Sorry, this item has already been claimed by someone else.";
    public string ClaimThisItem => "Claim this Item";
    public string ClaimThisItemDescription => "If you'd like to kindly buy this item for us, please press claim. You can unclaim it later if you change your mind.";
    public string Quantity => "Quantity";
    public string Claim => "Claim";
    
    public string RegistryInactiveDescription(string description) => $"The registry is {description}.";

    public string CreatedBy => "Created by";
    public string SourceCodeOn => "Source Code on";
    public string GitHub => "GitHub";
}