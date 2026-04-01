namespace WeddingWebsite.Models.People;

/// <summary>
/// Represents a person's name. Generally, only first and last name are used. These should be the preferred name.
/// </summary>
/// <param name="First">Preferred first name.</param>
/// <param name="Last">Preferred last name.</param>
/// <param name="LegalFirst">Legal first name, for official stuff.</param>
/// <param name="LegalLast">Legal last name, for official stuff.</param>
public record Name(string First, string Last, string? LegalFirst = null, string? LegalLast = null)
{
    public string Full => $"{First} {Last}";
    public string LegalFull => $"{LegalFirst ?? First} {LegalLast ?? Last}";

    public override string ToString() {
        return Full;
    }
}