namespace WeddingWebsite.Core.Emails;

public interface IEmailSender
{
    /// <summary>
    /// Sends an email. The message can be either HTML or plaintext.
    /// </summary>
    Task SendEmailAsync(string email, string subject, string message, bool isHtml = false);
}