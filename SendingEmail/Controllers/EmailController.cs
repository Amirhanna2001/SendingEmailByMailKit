using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using static Org.BouncyCastle.Math.EC.ECCurve;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using SendingEmail.Services;
using SendingEmail.DTOs;

namespace SendingEmail.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IEmailServices _emailServices;

    public EmailController(IEmailServices emailServices)
    {
        _emailServices = emailServices;
    }

    [HttpPost]
    public IActionResult SendEmail(EmailDTO dto)
    {
       _emailServices.SendEmail(dto);
        return Ok("Email sent successfully");
    }

}
