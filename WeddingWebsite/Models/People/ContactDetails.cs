namespace WeddingWebsite.Models.People;

public record ContactDetails
{
    private IDictionary<ContactUrgency, ContactOptions> OptionsByUrgency { get; }
    
    public ContactDetails(ContactOptions notUrgentOptions, ContactOptions urgentOptions) {
        OptionsByUrgency = new Dictionary<ContactUrgency, ContactOptions> {
            { ContactUrgency.Urgent, urgentOptions },
            { ContactUrgency.NotUrgent, notUrgentOptions }
        };
    }
    
    public ContactDetails(ContactOptions notUrgentOptions) {
        OptionsByUrgency = new Dictionary<ContactUrgency, ContactOptions> {
            { ContactUrgency.NotUrgent, notUrgentOptions },
            { ContactUrgency.Urgent, new ContactOptions([], []) }
        };
    }
    
    public ContactDetails() {
        OptionsByUrgency = new Dictionary<ContactUrgency, ContactOptions>();
    }

    public ContactOptions GetOptions(ContactUrgency urgency) {
        return OptionsByUrgency[urgency];
    }
    
    public IEnumerable<IContactOption> GetAllOptions() {
        return OptionsByUrgency.Values.SelectMany(o => o.Methods).Distinct();
    }
    
    public ContactOptions Urgent => OptionsByUrgency.TryGetValue(ContactUrgency.Urgent, out var option) ? option : new ([], []);
    public ContactOptions NotUrgent => OptionsByUrgency.TryGetValue(ContactUrgency.NotUrgent, out var option) ? option : new ([], []);
}
