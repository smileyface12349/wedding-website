using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using WeddingWebsite.Models.ConfigInterfaces;

namespace WeddingWebsite.Core.Emails;

public class MailKitEmailSender(ICredentials credentials) : IEmailSender
{
    private readonly EmailConfiguration config = credentials.EmailConfiguration;

    public async Task SendEmailAsync(string recipient, string subject, string message, bool isHtml = false)
    {
        if (string.IsNullOrEmpty(config.Host) || config.Port == 0)
            throw new InvalidOperationException("Please fill in the email credentials to send emails.");
        
        var email = new MimeMessage();

        var sender = MailboxAddress.Parse(config.From);
        if (!string.IsNullOrEmpty(config.Name))
            sender.Name = config.Name;
        email.Sender = sender;
        email.From.Add(sender);
        email.To.Add(MailboxAddress.Parse(recipient));
        email.Subject = subject;
        email.Body = new TextPart(isHtml ? TextFormat.Html : TextFormat.Text) { Text = message };

        using var smtp = new SmtpClient();
        smtp.Timeout = 10000;
        await smtp.ConnectAsync(config.Host, config.Port, config.EnableSSL);
        if (!string.IsNullOrEmpty(config.Username))
            await smtp.AuthenticateAsync(config.Username, config.Password);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}