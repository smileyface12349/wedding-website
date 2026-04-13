using WeddingWebsite.Data.Models;
using WeddingWebsite.Models.Emails.Variables;

namespace WeddingWebsite.Models.Emails;

/// <summary>
/// Email variable base class.
/// </summary>
public abstract class EmailVariable
{
    /// <summary>
    /// Pattern without % or parameters, e.g. "FIRST_NAMES".
    /// </summary>
    public abstract string Pattern { get; }
    
    /// <summary>
    /// Method to get the value given an account and filters.
    /// </summary>
    public abstract string GetValue(AccountWithGuests account, EmailFilters filters, string args);
    
    /// <summary>
    /// Description for user info.
    /// </summary>
    public abstract string Description { get; }
    
    /// <summary>
    /// Example for user info.
    /// </summary>
    public abstract string Example { get; }

    /// <summary>
    /// All available email variables.
    /// </summary>
    public static IEnumerable<EmailVariable> EmailVariables =>
    [
        new EmailEmailVariable(),
        new UsernameEmailVariable(),
        new FirstNamesEmailVariable(),
        new FamilyNameEmailVariable(),
        new FullNamesEmailVariable(),
        new GroupedNamesEmailVariable(),
        new NumGuestsEmailVariable()
    ];

    /// <summary>
    /// Apply this filter to input text, returning the new text
    /// </summary>
    public string Apply(string input, AccountWithGuests account, EmailFilters filters)
    {
        var patternWithArgs = $@"%{Pattern}(?:\(([^%]+)\))?%";
        return System.Text.RegularExpressions.Regex.Replace(input, patternWithArgs, match =>
        {
            var args = match.Groups[1].Value; // This will be empty if there are no parentheses
            return GetValue(account, filters, args);
        });
    }
}