using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Pustok.Database.DomainModels;

namespace Pustok.Controllers.Admin
{
    public class MailController : Controller
    {
        [Route("admin/Email")]

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest) 
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress(mailRequest.Name, mailRequest.SenderMail);
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo =new MailboxAddress(mailRequest.Name,mailRequest.RecieverMail);

            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate(mailRequest.Name, mailRequest.Password);
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }
    }
}
