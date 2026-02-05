namespace WeddingWebsite.Models.Rsvp;

public abstract record RsvpQuestionType
{
    public sealed record FreeText(RsvpDataColumn DataColumn, int MaxLength, string? Placeholder = null) : RsvpQuestionType
    {
        public override IEnumerable<RsvpDataColumn> GetAllColumns()
        {
            return [DataColumn];
        }
        
        public override string? GetAnswerString(IReadOnlyList<string?> data)
        {
            return data.ElementAtOrDefault(DataColumn.Id);
        }
    }

    public sealed record Select(RsvpDataColumn DataColumn, IEnumerable<String> Options, FreeText? OtherField) : RsvpQuestionType
    {
        public override IEnumerable<RsvpDataColumn> GetAllColumns()
        {
            return [DataColumn];
        }
        
        public override string? GetAnswerString(IReadOnlyList<string?> data)
        {
            return data.ElementAtOrDefault(DataColumn.Id);
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
        
        public override string? GetAnswerString(IReadOnlyList<string?> data)
        {
            var selectedOptions = Options
                .Where(option => data.ElementAtOrDefault(option.DataColumn.Id) == "Y")
                .Select(option => option.Option);
            
            if (OtherField != null)
            {
                var otherValue = data.ElementAtOrDefault(OtherField.DataColumn.Id);
                if (!string.IsNullOrEmpty(otherValue))
                {
                    selectedOptions = selectedOptions.Append(otherValue);
                }
            }
            
            return selectedOptions.Any() ? string.Join(", ", selectedOptions) : "No options selected";
        }
    }

    public abstract IEnumerable<RsvpDataColumn> GetAllColumns();
    public abstract string? GetAnswerString(IReadOnlyList<string?> data);
}