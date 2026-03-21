namespace WeddingWebsite.Models.Rsvp;

public abstract record RsvpQuestionType
{
    /// <summary>
    /// Allow the user to enter any text with their keyboard.
    /// </summary>
    /// <param name="DataColumn">Where the data should be stored.</param>
    /// <param name="MaxLength">Maximum length is required - do not set this too high!</param>
    /// <param name="Placeholder">Shows in the field when empty.</param>
    /// <param name="Lines">Controls how tall it is. Uses input element for one line and textarea otherwise.</param>
    public sealed record FreeText(RsvpDataColumn DataColumn, int MaxLength, string? Placeholder = null, int Lines = 1) : RsvpQuestionType
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

    /// <summary>
    /// Allow the user to select one item from a list of options. If OtherField is provided, the user can also enter
    /// free text. Please note that the free text is stored in the main column, and the auxiliary column merely stores
    /// a boolean state indicating whether the user has selected the "Other" option or not.
    /// </summary>
    public sealed record Select(RsvpDataColumn DataColumn, IEnumerable<Select.Option> Options, FreeText? OtherField = null) : RsvpQuestionType
    {
        public Select(RsvpDataColumn DataColumn, IEnumerable<string> Options, FreeText? OtherField = null) : this(DataColumn, Options.Select(option => new Option(option)), OtherField) {}
        
        public override IEnumerable<RsvpDataColumn> GetAllColumns()
        {
            if (OtherField != null)
            {
                return [DataColumn, OtherField.DataColumn];
            }
            return [DataColumn];
        }
        
        /// <summary>
        /// Outputs the user-friendly version, which then gets stored in dataByQuestion. Note that dataByColumn contains the raw data.
        /// </summary>
        public override string? GetAnswerString(IReadOnlyList<string?> data)
        {
            var storedValue = data.ElementAtOrDefault(DataColumn.Id);
            
            // Left blank
            if (storedValue == "")
            {
                return "";
            }
            
            // Handle "other" responses
            if (OtherField != null && data.ElementAtOrDefault(OtherField.DataColumn.Id) == "Y")
            {
                return storedValue;
            }
            
            // Match to a predefined option. If not, just output the raw data.
            return Options.FirstOrDefault(option => option.Identifier == storedValue)?.DisplayValue ?? storedValue;
        }

        public sealed record Option(string Identifier, string DisplayValue)
        {
            public Option (string value) : this(value, value) {}

            public override string ToString()
            {
                return DisplayValue;
            }
        }
    }

    /// <summary>
    /// Allow the user to select multiple items from a list of options. Each option is stored as a separate boolean
    /// column, with "Y" for true and "" for false. If OtherField is provided, the user can also enter free text which
    /// is stored in a separate column.
    /// </summary>
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
        
        public static string BoolToString(bool value)
        {
            return value ? "Y" : "";
        }

        public static bool StringToBool(string? value)
        {
            return value != null && value.ToLower().Contains("y");
        }
    }

    public abstract IEnumerable<RsvpDataColumn> GetAllColumns();
    public abstract string? GetAnswerString(IReadOnlyList<string?> data);
}