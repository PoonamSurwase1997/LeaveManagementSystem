using Microsoft.Extensions.Configuration;

namespace LeaveManagementSystem.Application.Service.Email
{
    public class EmailSender(IConfiguration _configration) : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //var fromAddress = _configration["EmailSettings:DefaultEmailAddress"];
            //var smtpServer = _configration["EmailSettings:Server"];
            //var smtpPort = Convert.ToInt32(_configration["EmailSettings:Port"]);
            //var message = new MailMessage
            //{
            //    Subject = subject,
            //    Body = htmlMessage,
            //    From = new MailAddress(fromAddress),
            //    IsBodyHtml = true
            //};

            //message.To.Add(new MailAddress(email));
            //using var client = new SmtpClient(smtpServer, smtpPort);
            //await client.SendMailAsync(message);
        }
    }
}
