using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Spinit.Data.Servicess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Spinit.Data.Services.Repository
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public class MessageSenderRepository : IMessageSender
    {
        private readonly IConfiguration _configuration;
        public MessageSenderRepository(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
  

        public void SendEmailAsync(string email, string subject, string message)
        {
            using (MailMessage mailmessage = new MailMessage(_configuration.GetValue<string>("Messaging:email"), email))
            {
                mailmessage.Subject = subject;

                mailmessage.Body = message;
                mailmessage.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = _configuration.GetValue<string>("Messaging:Host");
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(_configuration.GetValue<string>("Messaging:email"),
                    _configuration.GetValue<string>("Messaging:Pwd"));
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = Convert.ToInt32(_configuration.GetValue<string>("Messaging:Port"));
                smtp.Send(mailmessage);
            }

        }


        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
