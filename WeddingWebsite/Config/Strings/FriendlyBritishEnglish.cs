using WeddingWebsite.Models.ConfigInterfaces;

namespace WeddingWebsite.Config.Strings;

/// <summary>
/// A slight modification on the standard British English that makes some of the strings longer and more friendly.
/// This is great if you want a more relaxed and informal tone, and don't mind the extra length.
/// </summary>
public class FriendlyBritishEnglish : StandardBritishEnglish, IStringProvider
{
    public new string AccountSharedWithGuests(int guestCount) =>  $"This account is shared between {guestCount} guest{(guestCount != 1 ? "s" : "")}. Feel free to share your login details amongst all the guests tied to this account (they won't be able to access the website otherwise).";
    
    public new string RegistryDescription1 => "Please do not feel under any pressure to give a gift - there is no obligation at all to do so! However, if you would like to give a gift, this page contains some suggestions of things we'd like. If you'd prefer to give something else, that's fine too!";
    public new string RegistryDescription2 => "You can click on an item to view more information about it. Once you've decided to purchase it, please claim it so that we don't get multiple people buying the same thing!";
    
    public new string DoNotPurchaseBeforeClaiming => "Please do not make a purchase before claiming the item first - this will reserve it so we don't get two people buying the same thing!";
    public new string NotesDescription => "If you'd like to add any notes, you can do so in the box below. It's entirely up to you how you want to use this, if at all.";
    public new string SelectPurchaseMethodDescription => "Thank you so much for offering to purchase this item! The next step is to choose how you would like to purchase it.";
    public new string SelectDeliveryAddressDescription => "You can either get it delivered to your own address and bring it on the day, or get it delivered to us beforehand - it's up to you what's easiest!";
    public new string ItemReadyToPurchaseDescription => "Thank you for filling in those details! You're now free to complete the purchase when you're ready. Once done, please mark it as completed.";
    public new string ClaimThisItemDescription => "If you'd like to kindly buy this item for us, the first step is to claim it so that nobody else can buy this item. Once it's claimed, you'll be asked how you want to purchase it. Don't worry, this can be undone if you change your mind.";
}