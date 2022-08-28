using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace LeaveManagement.Web.Services
{
    public class EmailSender : IEmailSender
    {
        private string smtpServer;
        private int smtpPort;
        private string fromEmailAdderss;

        public EmailSender(string smtpServer, int smtpPort, string fromEmailAdderss)
        {
            this.smtpServer = smtpServer;
            this.smtpPort = smtpPort;
            this.fromEmailAdderss = fromEmailAdderss;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MailMessage
            {
                From = new MailAddress(fromEmailAdderss),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true

            };

            message.To.Add(new MailAddress(email));

            using(var client = new SmtpClient(smtpServer,smtpPort))
            {
                client.Send(message);
            }
            return Task.CompletedTask;

        }
    }
}
