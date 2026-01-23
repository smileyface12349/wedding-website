using Microsoft.AspNetCore.Components;
using WeddingWebsite.Models.ConfigInterfaces;

namespace WeddingWebsite.Config.Strings;

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
    public string AccountSharedWithGuests(int guestCount) =>  $"This account is shared between {guestCount} guest{(guestCount != 1 ? "s" : "")}. Feel free to share your login details amongst all the guests tied to this account (they won't be able to access the website otherwise).";
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
    
    public string Registry => "Registry";
    public string RegistryDescription1 =>
        "Please do not feel under any pressure to give a gift - there is no obligation at all to do so! However, if you would like to give a gift, this page contains some suggestions of things we'd like. If you'd prefer to give something else, that's fine too!";
    public string RegistryDescription2 => "You can click on an item to view more information about it. Once you've decided to purchase it, please claim it so that we don't get multiple people buying the same thing!";
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
    public string DoNotPurchaseBeforeClaiming => "Please do not make a purchase before claiming the item first - this will reserve it so we don't get two people buying the same thing!";
    public string DoNotPurchaseBeforeDetails => "Please finish selecting the details below before making a purchase.";
    public string CurrencySymbol => "£";
    public string CurrencyAmount(decimal amount)=> $"{CurrencySymbol}{amount:F2}";
    public string DeliveryCost(decimal cost) => $"+{CurrencyAmount(cost)} delivery";
    public string ItemPurchased => "Item Purchased";
    public string ThankYouForGift => "Thank you so much for your gift!";
    public MarkupString QuantityPurchased(int quantity) => (MarkupString) $"Quantity purchased: <b>{quantity}</b>.";
    public MarkupString PurchaseMethod(string purchaseMethod) => (MarkupString) $"Purchase method: <b>{purchaseMethod}</b>.";
    public MarkupString DeliveryAddress(string? address)  => (MarkupString) $"Delivery address: <b>{address}</b>.";
    public string RegistryClaimedContact(string? contactMethod) => $"Since this is now completed, you can no longer make any changes. If something went wrong, please contact {contactMethod}.";
    public string Notes => "Notes";
    public string NotesDescription => "If you'd like to add any notes, you can do so in the box below. It's entirely up to you how you want to use this, if at all.";
    public string NotesPlaceholder => "Add a note visible to you and the website administrators (optional).";
    public string SaveNotes => "Save Notes";
    public string SelectPurchaseMethod => "Select Purchase Method";
    public MarkupString SelectedQuantity(int quantity) => (MarkupString) $"Selected quantity: <b>{quantity}</b>.";
    public string SelectPurchaseMethodDescription => "Thank you so much for offering to purchase this item! The next step is to choose how you would like to purchase it.";
    public string SelectDeliveryAddress => "Select Delivery Address";
    public MarkupString SelectedPurchaseMethod(string purchaseMethod) => (MarkupString) $"Selected purchase method: <b>{purchaseMethod}</b>.";
    public string SelectDeliveryAddressDescription => "You can either get it delivered to your own address and bring it on the day, or get it delivered to us beforehand - it's up to you what's easiest!";
    public string BringOnTheDay => "I'll bring it on the day";
    public string ItemReadyToPurchase => "Item Ready to Purchase";
    public MarkupString SelectedDeliveryAddress(string? address) => (MarkupString) $"Selected delivery address: <b>{address}</b>.";
    public string ItemReadyToPurchaseDescription => "Thank you for filling in those details! You're now free to complete the purchase when you're ready. Once done, please mark it as completed.";
    public string GoToPurchasePage => "Go to Purchase Page";
    public MarkupString CustomPurchaseInstructions(string? instructions) => (MarkupString) $"<b>Instructions:</b> {instructions}";
    public string MarkAsCompleted => "Mark as Completed (cannot be undone)";
    public string UnclaimDescription => "If you've changed your mind and you'd no longer like to buy this item, please unclaim it to make it available to others.";
    public string Unclaim => "Unclaim";
    public string ItemClaimed => "Item Already Claimed";
    public string ItemClaimedDescription => "Sorry, this item has already been claimed by someone else.";
    public string ClaimThisItem => "Claim this Item";
    public string ClaimThisItemDescription =>
        "If you'd like to kindly buy this item for us, the first step is to claim it so that nobody else can buy this item. Once it's claimed, you'll be asked how you want to purchase it.";
    public string Quantity => "Quantity";
    public string Claim => "Claim";
    
    public string RegistryInactiveDescription(string description) => $"The registry is {description}.";

    public string CreatedBy => "Created by";
    public string SourceCodeOn => "Source Code on";
    public string GitHub => "GitHub";
}