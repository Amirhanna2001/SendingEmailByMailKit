using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using SendingEmail.DTOs;
using MailKit.Net.Smtp;

namespace SendingEmail.Services;

public class EmailServices : IEmailServices
{
    private readonly IConfiguration _config;

    public EmailServices(IConfiguration config)
    {
        _config = config;
    }

    public void SendEmail(EmailDTO dto)
    {
        MimeMessage email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_config["Email"]));
        email.To.Add(MailboxAddress.Parse(dto.To));
        email.Subject = "Email For Verify your Registration";
        email.Body = new TextPart(TextFormat.Text) { Text = dto.Body };

        using var smtp = new SmtpClient();
        smtp.Connect(_config["EmailHost"], 587, SecureSocketOptions.StartTls);
        smtp.Authenticate(_config["Email"], _config["Password"]);

        smtp.Send(email);
        smtp.Disconnect(true);
    }
}
