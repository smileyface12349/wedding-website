namespace WeddingWebsite.Models.Rsvp;

/// <summary>
/// A list of questions and some validation logic to apply to them
/// </summary>
public record RsvpQuestions(
    IEnumerable<RsvpQuestion> Questions,
    Func<IList<string?>, IEnumerable<string>>? Validator = null
)
{
    /// <summary>
    /// Validates the form on the inputs. Returns an empty list if everything is okay, and a list of error messages
    /// otherwise.
    /// </summary>
    public IEnumerable<string> Validate(IList<string?> data)
    {
        IEnumerable<string> issues = CheckRequiredFields(data);
        
        if (Validator == null)
        {
            return issues;
        }
        else
        {
            return issues.Concat(Validator(data));
        }
    }

    private IEnumerable<string> CheckRequiredFields(IList<string?> data)
    {
        IList<string> issues = [];
        
        foreach (var question in Questions.Where(q => q.Required))
        {
            var columns = question.QuestionType.GetAllColumns().Select(column => column.Id);
            if (columns.All(col => data[col] == null || data[col] == ""))
            {
                issues.Add($"Please complete this question: {question.Title}");
            }
        }

        return issues;
    }

    public IEnumerable<RsvpDataColumn> GetAllColumns()
    {
        IList<RsvpDataColumn> columns = new List<RsvpDataColumn>();
        foreach (var question in Questions)
        {
            foreach (var column in question.QuestionType.GetAllColumns())
            {
                columns.Add(column);
            }
        }

        return columns;
    }
}