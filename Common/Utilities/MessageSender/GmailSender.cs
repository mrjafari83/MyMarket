using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Common.Utilities.MessageSender
{
    public class GmailSender : IMessageSender
    {
        public Task SendAsync(string toMail, string subject, string message, bool isMessageHtml = false)
        {
            using(var client = new SmtpClient())
            {
                var credential = new NetworkCredential() 
                {
                    UserName = "",
                    Password = ""
                };

                client.Credentials = credential;
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;

                var emailMessage = new MailMessage()
                {
                    To = { new MailAddress(toMail) },
                    From = new MailAddress(""),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = isMessageHtml,
                };

                client.Send(emailMessage);
                return Task.CompletedTask;
            }
        }
    }
}
