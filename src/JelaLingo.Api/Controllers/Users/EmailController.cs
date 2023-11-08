using JelaLingo.Service.Interfaces.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JelaLingo.Api.Controllers.Users;

public class EmailController : BaseController
{
    private readonly IEmailService emailService;
    public EmailController(IEmailService emailService)
    {
        this.emailService = emailService;
    }

    [HttpPost]
    public async ValueTask<ActionResult> EmailAsync([FromForm] string to, [FromForm] string subject, [FromForm] string message)
    {
        await emailService.SendEmailAsync(to, subject, message);
        return Ok();
    }
}
