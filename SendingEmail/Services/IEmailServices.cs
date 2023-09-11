using SendingEmail.DTOs;

namespace SendingEmail.Services;

public interface IEmailServices
{
    void SendEmail(EmailDTO dto);
}
