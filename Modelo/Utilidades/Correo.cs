using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;
using dotenv.net;

namespace Modelo.Utilidades
{
    public class Correo
    {
        private string _fromEmail;
        private string _clave;
        private string _smtpHost;
        private int _smtpPort;
        public void readCredentials()
        {
            var envVars = DotEnv.Read();
            _fromEmail = envVars["EMAIL_FROM"];
            _clave = envVars["EMAIL_PASSWORD"];
            _smtpHost = envVars["SMTP_HOST"];
            _smtpPort = int.Parse(envVars["SMTP_PORT"]);
        }

        public void SendEmail(string subject, string body, string toEmail)
        {
            readCredentials();
            try
            {
                var message = new MailMessage
                {
                    From = new MailAddress(_fromEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };

                message.To.Add(toEmail);

                using (var client = new SmtpClient(_smtpHost, _smtpPort))
                {
                    client.Credentials = new NetworkCredential(_fromEmail, _clave);
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
