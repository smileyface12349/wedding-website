// Yes, this really is the best way. Docs aren't supported in .razor files, so it would need to be a code-behind file.
// Instead of creating an extra file for each component, I thought I'd dump them all in here.

namespace WeddingWebsite.Components.Containers
{
    /// <summary>
    /// A box which changes type depending on the cascading SectionTheme.
    /// Type is either <see cref="OutlinedBox"/> or <see cref="RoundedCornerBox"/>.
    /// </summary>
    /// <param name="ChildContent">The content to be placed within the default padding.</param>
    /// <param name="TopContent">(Optional) The content to be placed above the normal content, with no padding.</param>
    partial class Box {}
    
    /// <summary>
    /// Aligns all child content to the right using flex. May be used for one or more elements.
    /// </summary>
    /// <param name="ChildContent">Child content</param>
    partial class FlexRight {}
    
    /// <summary>
    /// A box which has sharp square corners and a dark border.
    /// Please use <see cref="Box"/> instead to use the box style inherited from the current theme.
    /// </summary>
    /// <param name="ChildContent">The content to be placed within the default padding.</param>
    /// <param name="TopContent">(Optional) The content to be placed above the normal content, with no padding.</param>
    partial class OutlinedBox {}
    
    /// <summary>
    /// A box which has rounded corners and often filled in with a colour that contrasts the background.
    /// Please use <see cref="Box"/> instead to use the box style inherited from the current theme.
    /// </summary>
    /// <param name="ChildContent">The content to be placed within the default padding.</param>
    /// <param name="TopContent">(Optional) The content to be placed above the normal content, with no padding.</param>
    partial class RoundedCornerBox {}
    
    /// <summary>
    /// Places two things side by side. When the width gets to below 800px, the two things go on top of each other.
    /// </summary>
    /// <param name="LeftContent">Left content</param>
    /// <param name="RightContent">Right content</param>
    partial class SideBySide {}
}

namespace WeddingWebsite.Components.Dialogs
{
    /// <summary>
    /// A MudDialog that accepts a list of WebsiteSection classes for the content.
    /// These are rendered with headings for each section.
    /// Launched from <see cref="ModalButton"/>.
    /// </summary>
    partial class EventDialog {}
    
    /// <summary>
    /// A button that launches a <see cref="EventDialog"/> modal.
    /// </summary>
    /// <param name="Modal">A <see cref="WeddingWebsite.Models.WebsiteElement.WeddingModal"/> with all the details</param>
    partial class ModalButton {}
}

namespace WeddingWebsite.Components.Elements.Countdown
{
    /// <summary>
    /// Not designed for use outside of <see cref="CountdownToDate"/> or <see cref="CountdownToDateServer"/>.
    /// </summary>
    partial class BigColon {}
    
    /// <summary>
    /// Not designed for use outside of <see cref="CountdownToDate"/> or <see cref="CountdownToDateServer"/>.
    /// </summary>
    partial class DatePart {}
    
    /// <summary>
    /// A countdown to a particular future date in Months, Weeks, Days, Hours, Minutes and Seconds.
    /// Automatically re-renders every second on the client using JavaScript. Tested in conjunction with
    /// InteractiveServer render mode.
    /// 
    /// Warning: There is currently some weirdness with timezones and inconsistency between client/server, which should
    /// be fixed if you have guests in multiple timezones.
    /// </summary>
    /// <param name="CountdownTo">The DateTime the countdown is until.</param>
    partial class CountdownToDate {}
    
    /// <summary>
    /// A version of <see cref="CountdownToDate"/> which renders entirely server-side (or can be client-side if moved
    /// to the client project). Displaying seconds is disabled by default as it causes a lot of requests and the timer
    /// will not appear smooth on most internet connections.
    /// </summary>
    /// <param name="CountdownTo">The DateTime the countdown is until.</param>
    /// <param name="ShowSeconds">Whether to display the seconds counter. Defaults to false.</param>
    partial class CountdownToDateServer {}
}

namespace WeddingWebsite.Components.Elements
{
    /// <summary>
    /// A mini google maps widget. Requires <see cref="WeddingWebsite.Models.Credentials.IGoogleMapsApiKey"/> to be
    /// registered as a service. Please restrict your API key to your domain name only.
    /// </summary>
    /// <param name="Location">The <see cref="WeddingWebsite.Models.Location"/>.</param>
    /// <param name="Height">(Optional) The height, as a string with CSS units.</param>
    /// <param name="ClassName">(Optional) Class name for additional styles. Make sure ::deep is applied.</param>
    partial class GoogleMapsEmbed {}
    
    /// <summary>
    /// Renders an <see cref="WeddingWebsite.Models.WebsiteElement.IWebsiteElement"/>. Please note there are no
    /// compile-time checks to ensure that any new implementations of this interface are covered by this element.
    /// All website elements are configured to fill the width of the parent element by default.
    /// </summary>
    /// <param name="Element">The <see cref="WeddingWebsite.Models.WebsiteElement.IWebsiteElement"/>.</param>
    /// <param name="MaxHeight">(Optional) This is sometimes passed as the exact height, and sometimes the max height.</param>
    /// <param name="ClassName">(Optional) Class name for additional styles. Make sure ::deep is applied.</param>
    partial class WebsiteElement {}
    
    /// <summary>
    /// A green "yes" button and a red "no" button that the user can toggle between.
    /// </summary>
    /// <param name="Value">A bool. Use the two-way bind @bind-Value="your_var" to listen to updates.</param>
    partial class YesOrNoToggleGroup {}
}

namespace WeddingWebsite.Components.Interactivity
{
    /// <summary>
    /// Embeds a JavaScript script on the page, properly. This script should export the methods onLoad, onUpdate and
    /// onDispose. Often used from within components to link the scoped js file.
    /// </summary>
    /// <param name="Src">The absolute path to the JavaScript file.</param>
    partial class PageScript {}
}

namespace WeddingWebsite.Components.Sections
{
    /// <summary>
    /// The class to use for every section of the website. Spans the full horizontal width and applies a background
    /// depending on the cascading SectionTheme. Also limits the max width.
    /// </summary>
    /// <param name="ChildContent">Content to go in the section.</param>
    /// <param name="Center">(Optional) Applies text-align: center if true. Defaults to false.</param>
    /// <param name="Padding">(Optional) Whether to apply padding on the top and bottom. Left and right padding is
    /// always on and cannot be disabled. Defaults to true.</param>
    /// <param name="Id">(Optional) Custom ID to use for anchors.</param>
    /// <param name="Background">(Optional) Default CSS background that is overridden by the SectionTheme.</param>
    partial class Section {}
    
    /// <summary>
    /// A heading to go at the top of a <see cref="Section"/>. There should be at most one heading per section.
    /// </summary>
    /// <param name="ChildContent">The content for the heading. This should probably just be text.</param>
    partial class SectionHeading {}
    
    /// <summary>
    /// A section with two themed boxes side-by-side. Boxes are displayed on top of each other on narrow screens.
    /// </summary>
    /// <param name="Box1">Content to go in the left box.</param>
    /// <param name="Box2">Content to go in the right box.</param>
    partial class TwoBoxesSection {}
}

namespace WeddingWebsite.Components.WeddingComponents
{
    /// <summary>
    /// Displays accommodation options as a table.
    /// </summary>
    /// <param name="AccommodationDetails">The <see cref="WeddingWebsite.Models.AccommodationDetails"/>.</param>
    partial class AccommodationList {}
    
    /// <summary>
    /// Displays suggested contacts for a user-input category and urgency. This renders server-side.
    /// </summary>
    /// <param name="Contacts">A list of all the <see cref="WeddingWebsite.Models.People.IContact"/>s.</param>
    /// <param name="ReasonsToShow">Which reasons to show. Should come from the config.</param>
    /// <param name="ShowUrgencyOption">Whether to enable the urgency option. Should come from the config. </param>
    partial class ContactList {}
    
    /// <summary>
    /// Displays events as a list. See <see cref="WeddingTimeline"/> for a timeline view which also contains travel
    /// directions and accommodation details.
    /// </summary>
    /// <param name="Events">The <see cref="WeddingWebsite.Models.Event"/>s to show.</param>
    partial class EventList {}
    
    /// <summary>
    /// Displays introductions for the specified people in a vertical list. Has an alternate display mode using chat
    /// messages.
    /// </summary>
    /// <param name="People">The list of <see cref="WeddingWebsite.Models.People.NotablePerson"/> to show.</param>
    /// <param name="IsOnLeftSide">This may affect how the component is rendered when done side-by-side.</param>
    /// <param name="DisplayMode">Whether to use the default view or the chat view.</param>
    partial class MeetWeddingParty {}
    
    /// <summary>
    /// Not designed to be used outside of <see cref="WeddingTimeline"/>.
    /// </summary>
    partial class TimelineItemBox {}
    
    /// <summary>
    /// A vertical list of validation issues, each one in a themed box.
    /// </summary>
    /// <param name="Issues">The <see cref="WeddingWebsite.Models.Validation.ValidationIssue"/>s.</param>
    partial class ValidationIssuesForSeverity {}
    
    /// <summary>
    /// Lists all validation issues, grouped by severity. Errors and Warnings sections are always shown, Info section
    /// is only shown when non-empty.
    /// </summary>
    /// <param name="Issues">The <see cref="WeddingWebsite.Models.Validation.ValidationIssue"/>s.</param>
    partial class ValidationIssuesList {}
    
    /// <summary>
    /// A single wedding party introduction using the default display mode.
    /// </summary>
    /// <param name="Person">The <see cref="WeddingWebsite.Models.People.NotablePerson"/>.</param>
    partial class WeddingPartyIntroduction {}
    
    /// <summary>
    /// A single wedding party introduction using the chat display mode.
    /// </summary>
    /// <param name="Person">The <see cref="WeddingWebsite.Models.People.NotablePerson"/>.</param>
    /// <param name="IsOnLeftSide">This controls which way round the messages are.</param>
    partial class WeddingPartyIntroductionChat {}
    
    /// <summary>
    /// A timeline of events throughout the day, including the events and auto-generated travel directions sections.
    /// Also includes an accommodation section at the end.
    /// </summary>
    /// <param name="Events">The <see cref="WeddingWebsite.Models.Event"/>s.</param>
    /// <param name="AccommodationDetails">(Optional) The <see cref="WeddingWebsite.Models.AccommodationDetails"/>.</param>
    partial class WeddingTimeline {}
}

namespace WeddingWebsite.Components.WeddingSections
{
    /// <summary>
    /// An interactive section that suggests contacts based on the reason and urgency. Currently renders server-side.
    /// </summary>
    /// <param name="ReasonsToShow">The <see cref="WeddingWebsite.Models.People.ContactReason"/>s to show in the
    /// dropdown.</param>
    /// <param name="ShowUrgencyOption">Whether to show the urgency option.</param>
    partial class ContactSection {}
    
    /// <summary>
    /// A section with a countdown timer. Note that you may prefer to have the countdown timer in the top section.
    /// </summary>
    partial class CountdownSection {}
    
    /// <summary>
    /// A "meet the wedding party" section with a little background on each person from the specified roles. Displays
    /// two columns side-by-side.
    /// </summary>
    /// <param name="DisplayMode">A <see cref="WeddingWebsite.Models.WebsiteConfig.MeetWeddingPartyDisplay"/>.</param>
    /// <param name="RolesLeft">The <see cref="WeddingWebsite.Models.People.Role"/>s for the left hand side.</param>
    /// <param name="RolesRight">The <see cref="WeddingWebsite.Models.People.Role"/>s for the right hand side.</param>
    partial class MeetWeddingPartySection {}
    
    /// <summary>
    /// A section with a timeline of events throughout the day, including auto-generated travel directions and
    /// accommodation details.
    /// </summary>
    /// <param name="ShowHeading">(Optional) Whether to show the heading, instead of the timeline running right to the
    /// edge. Defaults to false.</param>
    partial class TimelineSection {}
    
    /// <summary>
    /// A section showing all the validation issues caught by the
    /// <see cref="WeddingWebsite.Models.Validation.IDetailsAndConfigValidator"/>. This is invisible in production.
    /// </summary>
    partial class ValidationSection {}
}