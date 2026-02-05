namespace WeddingWebsite.Models.Rsvp;

public abstract record RsvpQuestionType
{
    public sealed record FreeText(RsvpDataColumn DataColumn, int MaxLength, string? Placeholder = null) : RsvpQuestionType
    {
        public override IEnumerable<RsvpDataColumn> GetAllColumns()
        {
            return [DataColumn];
        }
    }

    public sealed record Select(RsvpDataColumn DataColumn, IEnumerable<String> Options, FreeText? OtherField) : RsvpQuestionType
    {
        public override IEnumerable<RsvpDataColumn> GetAllColumns()
        {
            return [DataColumn];
        }
    }

    public sealed record MultiSelect(IEnumerable<MultiSelectOption> Options, FreeText? OtherField) : RsvpQuestionType
    {
        public override IEnumerable<RsvpDataColumn> GetAllColumns()
        {
            if (OtherField != null)
            {
                return Options.Select(option => option.DataColumn).Append(OtherField.DataColumn);
            }
            else
            {
                return Options.Select(option => option.DataColumn);
            }
        }
    }

    public abstract IEnumerable<RsvpDataColumn> GetAllColumns();
}