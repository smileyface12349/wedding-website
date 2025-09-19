using WeddingWebsite.Models.People;
using WeddingWebsite.Models.WebsiteConfig;
using WeddingWebsite.Models.WeddingDetails;

namespace WeddingWebsite.Models.Validation;

public class DetailsAndConfigValidator: IDetailsAndConfigValidator
{
    private IList<ValidationIssue> validationIssues = [];
    
    public IEnumerable<ValidationIssue> Validate(IWeddingDetails details, IWebsiteConfig config) {
        validationIssues = [];
        
        Sections_ShouldNotBeEmpty(config);
        Sections_ShouldNotHaveDuplicates(config);
        
        People_ThereIsABrideAndGroom(details);
        
        Events_DoNotReturnToSameVenueTwice(details);
        Events_EarliestStartTimeIsFirstEvent(details);
        Events_LatestFinishTimeIsLastEvent(details);
        Events_IsNotEmpty(details);
        
        Contacts_HaveAtLeastOneContactForEachOption(details, config);
        Contacts_WhenUrgencyDisabled_ShouldNotHaveUrgentContacts(details, config);
        Contacts_InformAboutLoginContact(details);
        Contacts_ShouldNotHaveDuplicates(details);
        Contacts_ShouldNotHaveEmptyMethods_IfReasonsIsNonEmpty(details);

        return validationIssues;
    }
    
    /// <summary>
    /// A helper method to quickly obtain the first section of a particular type, or null if there isn't one.
    /// </summary>
    private static T? GetSection<T>(IWebsiteConfig config) where T:Section {
        foreach (var sect in config.Sections) {
            if (sect is T castedSection) {
                return castedSection;
            }
        }
        return default;
    }
    
    /// <summary>
    /// An error that leads to incorrect / misleading information, or severe and definitely undesired behaviour.
    /// These errors must still be recoverable i.e. the site should render without throwing.
    /// </summary>
    private void Error(string message) {
        validationIssues.Add(new ValidationIssue(ValidationIssueSeverity.Error, message));
    }
    
    /// <summary>
    /// An issue that seems weird, but may be valid. E.g. specifying data that's overridden by another setting.
    /// </summary>
    private void Warning(string message) {
        validationIssues.Add(new ValidationIssue(ValidationIssueSeverity.Warning, message));
    }
    
    /// <summary>
    /// Something worth flagging, but very unlikely to cause a problem.
    /// </summary>
    private void Info(string message) {
        validationIssues.Add(new ValidationIssue(ValidationIssueSeverity.Info, message));
    }
    
    
    
    /// <summary>
    /// A bride and groom are required for the homepage where it displays their names
    /// </summary>
    private void People_ThereIsABrideAndGroom(IWeddingDetails details) {
        if (details.NotablePeople.All(p => p.Role != Role.Bride)) {
            Error("There is no bride in the notable people list. This is required for the homepage.");
        }
        if (details.NotablePeople.All(p => p.Role != Role.Groom)) {
            Error("There is no groom in the notable people list. This is required for the homepage.");
        }
    }
    
    /// <summary>
    /// If there are no events, the timeline will not work properly.
    /// The countdown relies on the start time of the first event
    /// </summary>
    private void Events_IsNotEmpty(IWeddingDetails details) {
        if (!details.Events.Any()) {
            Warning("There are no events in the wedding details. This is required for the countdown timer and timeline.");
        }
    }
    
    /// <summary>
    /// Returning to the same venue will show the same travel directions.
    /// This constraint can be relaxed with a little extra coding to handle different travel directions based on origin.
    /// </summary>
    private void Events_DoNotReturnToSameVenueTwice(IWeddingDetails details) {
        var visited = new HashSet<string>();
        string? currentVenue = null;
        foreach (var ev in details.Events)
        {
            if (ev.Venue.Name == currentVenue) {
                continue;
            }
            if (visited.Contains(ev.Venue.Name)) {
                Error($"The venue {ev.Venue.Name} is visited in two different events from different locations. This will lead to the same travel directions for both, despite having a different origin. This is not currently supported.");
            }
            visited.Add(ev.Venue.Name);
            currentVenue = ev.Venue.Name;
        }
    }
    
    /// <summary>
    /// This assumption is made when determining the start time in the countdown timer.
    /// </summary>
    private void Events_EarliestStartTimeIsFirstEvent(IWeddingDetails details) {
        var firstStartTime = details.Events.First().Start;
        if (details.Events.Any(e => e.Start < firstStartTime)) {
            Error("The earliest start time must be the first element in the list. This is used for the countdown timer.");
        }
    }
    
    /// <summary>
    /// This assumption is made when determining the time to show alongside the accommodation details.
    /// </summary>
    private void Events_LatestFinishTimeIsLastEvent(IWeddingDetails details) {
        var lastFinishTime = details.Events.Last().End;
        if (lastFinishTime == null) {
            // An unspecified end time is a valid state
            Info("You haven't specified an end time for the final event. Giving a finish time may be useful for guests, and it will show up in the accommodation section.");
            return;
        }
        if (details.Events.Any(e => e.End != null && e.End > lastFinishTime)) {
            Error("The latest finish time must be the last element in the list. This is used for the accommodation details.");
        }
    }
    
    /// <summary>
    /// For every time of enquiry, there should be someone to contact.
    /// </summary>
    private void Contacts_HaveAtLeastOneContactForEachOption(IWeddingDetails details, IWebsiteConfig config) {
        var section = GetSection<Section.Contact>(config);
        if (section == null) return;
        foreach (var enquiryType in section.ReasonsToShow) {
            foreach (var urgency in new[] { ContactUrgency.NotUrgent, ContactUrgency.Urgent }) {
                var matchingContacts = details.NotablePeople.Concat(details.ExtraContacts)
                    .Where(p => p.ContactDetails.GetOptions(urgency).MatchesReason(enquiryType))
                    .ToList();
                if (!matchingContacts.Any()) {
                    Warning($"There are no contacts for reason {enquiryType} with urgency {urgency}. Consider adding a catch-all contact, or removing this enquiry type from display.");
                }
            }
        }
    }
    
    /// <summary>
    /// This is supplying data which won't be used. Flagging this early will prevent confusion later on.
    /// </summary>
    private void Contacts_WhenUrgencyDisabled_ShouldNotHaveUrgentContacts(IWeddingDetails details, IWebsiteConfig config) {
        var section = GetSection<Section.Contact>(config);
        if (section == null) return;
        if (!section.ShowUrgencyOption) {
            foreach (var contact in details.NotablePeople.Concat(details.ExtraContacts))
            {
                if (contact.ContactDetails.Urgent.Methods.Any()) {
                    Warning($"The contact '{contact.NameAndRole}' has urgent options, but you have disabled the urgency toggle in settings. Either re-enable this toggle, or remove all urgent contact options, as the urgent contact options will be ignored.");
                }
            }
        }
    }
    
    /// <summary>
    /// Doesn't cause any errors but seems a bit silly!
    /// </summary>
    private void Sections_ShouldNotBeEmpty(IWebsiteConfig config) {
        if (!config.Sections.Any()) {
            Warning("You haven't added any sections to your website! It'll be a bit boring... Go to the config file and add some sections into your website.");
        }
    }
    
    /// <summary>
    /// Doesn't cause any errors but seems a bit silly!
    /// </summary>
    private void Sections_ShouldNotHaveDuplicates(IWebsiteConfig config) {
        var sectionTypes = new HashSet<Type>();
        foreach (var section in config.Sections) {
            var type = section.GetType();
            if (sectionTypes.Contains(type)) {
                Warning($"You have two sections of type {type}. Are you sure you want two the same?");
            }
            sectionTypes.Add(type);
        }
    }

    /// <summary>
    /// Inform that a contact is visible to users who are signed out.
    /// </summary>
    private void Contacts_InformAboutLoginContact(IWeddingDetails details)
    {
        var contactMethod = details.LoginContactMethod;
        if (contactMethod != null)
        {
            Info($"The contact method {contactMethod.Text} is visible to users who are not signed in.");
        }
    }

    /// <summary>
    /// A user may think that all contacts need to be added to ExtraContacts and not just NotablePeople.
    /// </summary>
    private void Contacts_ShouldNotHaveDuplicates(IWeddingDetails details)
    {
        var duplicateContacts = details.NotablePeople.Concat(details.ExtraContacts).Select(contact => contact.NameAndRole).GroupBy(contact => contact).Where(group => group.Count() > 1).Select(group => group.Key);
        if (duplicateContacts.Any())
        {
            Warning($"There are duplicate contacts for {string.Join(", ", duplicateContacts)}. Did you accidentally add it to ExtraContacts when it's already in NotablePeople?");
        }
    }

    /// <summary>
    /// If you specify reasons to be contactable, you should specify methods to contact too. This affects some features
    /// which choose the first contact and rely on a method existing if there's a contact that exists.
    /// </summary>
    private void Contacts_ShouldNotHaveEmptyMethods_IfReasonsIsNonEmpty(IWeddingDetails details)
    {
        foreach (var contact in details.NotablePeople.Concat(details.ExtraContacts))
        {
            // This deliberately validates on every reason, not just those enabled in the contacts section, as there
            // are various sections using specific reasons even if they are not enabled for the section.
            foreach (var reason in Enum.GetValues<ContactReason>())
            {
                if (!contact.ContactDetails.Urgent.Methods.Any() && contact.ContactDetails.Urgent.MatchesReason(reason))
                {
                    Error($"{contact.NameAndRole} is listed as an urgent contact for reason {reason}, but there are no contact methods. Either add an urgent contact method, or remove this contact reason.");
                }
                if (!contact.ContactDetails.NotUrgent.Methods.Any() && contact.ContactDetails.NotUrgent.MatchesReason(reason))
                {
                    Error($"{contact.NameAndRole} is listed as a non-urgent contact for reason {reason}, but there are no contact methods. Either add a non-urgent contact method, or remove this contact reason.");
                }
            }
        }
    }
}