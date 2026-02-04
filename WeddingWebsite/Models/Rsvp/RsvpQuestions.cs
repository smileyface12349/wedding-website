namespace WeddingWebsite.Models.Rsvp;

/// <summary>
/// A list of questions and some validation logic to apply to them
/// </summary>
public record RsvpQuestions(
    IEnumerable<RsvpQuestion> Questions,
    Func<IReadOnlyList<string?>, IEnumerable<string>>? Validator = null
)
{
    /// <summary>
    /// Validates the form on the inputs. Returns an empty list if everything is okay, and a list of error messages
    /// otherwise.
    /// </summary>
    private IEnumerable<string> Validate(IReadOnlyList<string?> data)
    {
        if (Validator == null)
        {
            return [];
        }
        else
        {
            return Validator(data);
        }
    }
}