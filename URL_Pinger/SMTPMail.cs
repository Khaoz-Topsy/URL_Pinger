using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace URL_Pinger
{
    class SMTPMail
    {
        public static void Send(string Subject, string Message)
        {
            new Thread(() =>
            {
                try
                {
                    Thread.CurrentThread.IsBackground = true;

                    string ToEmail = SecretData.ToEmailAddress;
                    string FromEmail = SecretData.FromEmailAddress;
                    string Password = SecretData.Password;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = true,
                        Credentials = new NetworkCredential(FromEmail, Password)
                    };

                    using (var message = new MailMessage(FromEmail, ToEmail, Subject, Message))
                    {
                        smtp.Send(message);
                    }
                }
                catch (Exception) { }

            }).Start();
        }
    }
}