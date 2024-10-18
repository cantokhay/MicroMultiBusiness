using MailKit.Net.Smtp;
using MicroMultiBusiness.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace MicroMultiBusiness.WebUI.Controllers
{
    public class MailController : Controller
    {
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(MailRequest mailRequest)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Micro Multi Admin", "multiMicro14@gmail.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("User", mailRequest.ReceiverMail);
            message.To.Add(to);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Message;
            message.Body = bodyBuilder.ToMessageBody();

            message.Subject = mailRequest.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("multiMicro14@gmail.com", "yumo jcjc vevy wfae");
            client.Send(message);
            client.Disconnect(true);

            return View();
        }
    }
}
