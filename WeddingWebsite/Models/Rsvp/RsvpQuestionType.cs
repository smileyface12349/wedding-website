namespace WeddingWebsite.Models.Rsvp;

public abstract record RsvpQuestionType
{
    public sealed record FreeText(RsvpDataColumn DataColumn, int MaxLength, string? Placeholder=null) : RsvpQuestionType;
    public sealed record Select(RsvpDataColumn DataColumn, IEnumerable<String> Options, FreeText? OtherField) : RsvpQuestionType;
    public sealed record MultiSelect(IEnumerable<MultiSelectOption> Options, FreeText? OtherField) : RsvpQuestionType;
}