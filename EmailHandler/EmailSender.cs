using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailHandler
{
    public class EmailSender
    {

        public void SendEmail(string to, string subject,string body)
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient(Email.Default.SmtpServer);

                mail.From = new MailAddress(Email.Default.From);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;

                smtpServer.Port = Email.Default.Port;
                smtpServer.Credentials = new NetworkCredential(Email.Default.From, Email.Default.Password);
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
            }
            catch (Exception e)
            {
                var ex = e;
            }
        }

    }
}
