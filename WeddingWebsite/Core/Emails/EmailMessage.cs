using System.ComponentModel.DataAnnotations;

namespace WeddingWebsite.Core.Emails;

public class EmailMessage
{
    [EmailAddress]
    public string Recipient { get; set; } = string.Empty;

    [Required]
    public string Subject { get; set; } = string.Empty;

    [Required]
    public string Message { get; set; } = string.Empty;
}