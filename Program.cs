using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcoreapp
{
	public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<HttpStatusCode> SendEmail(string sender, string receiver, string subj, string content)
        {
            var apiKey = Environment.GetEnvironmentVariable("SendGridAPIKey");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(sender);
            var to = new EmailAddress(receiver);
            var subject = subj;
            var body = content;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, body, "");
            var response = await client.SendEmailAsync(msg);
            return response.StatusCode;
        }
    }
}
