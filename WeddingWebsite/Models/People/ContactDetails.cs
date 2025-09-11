namespace WeddingWebsite.Models.People;

public record ContactDetails
{
    private IDictionary<ContactUrgency, ContactOptions> OptionsByUrgency { get; }
    
    public ContactDetails(ContactOptions urgentOptions, ContactOptions notUrgentOptions) {
        OptionsByUrgency = new Dictionary<ContactUrgency, ContactOptions> {
            { ContactUrgency.Urgent, urgentOptions },
            { ContactUrgency.NotUrgent, notUrgentOptions }
        };
    }

    public ContactOptions GetOptions(ContactUrgency urgency) {
        return OptionsByUrgency[urgency];
    }
    
    public IEnumerable<IContactOption> GetAllOptions() {
        return OptionsByUrgency.Values.SelectMany(o => o.Methods).Distinct();
    }
    
    public ContactOptions Urgent => OptionsByUrgency[ContactUrgency.Urgent];
    public ContactOptions NotUrgent => OptionsByUrgency[ContactUrgency.NotUrgent];
}
