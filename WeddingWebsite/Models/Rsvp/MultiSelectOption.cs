namespace WeddingWebsite.Models.Rsvp;

/// <summary>
/// Multi-select fields store a yes/no value for each option, so each option needs to be given its own unique field.
/// </summary>
public record MultiSelectOption(string Option, RsvpDataColumn DataColumn);