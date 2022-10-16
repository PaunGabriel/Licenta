using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Spinit.Data.Servicess.Infrastructure
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public interface IMessageSender 
    {


        void SendEmailAsync(string email, string subject, string message);




         Task SendSmsAsync(string number, string message);
        
        
    }
}
